using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Suporte_TI.Data;
using Suporte_TI.Models;
using System.Text.Json;


namespace Suporte_TI.Forms
{
    public partial class NovoChamadoForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string ApiUrl = "http://localhost:5222/api/deepseek/chamada";
        public NovoChamadoForm()
        {
            InitializeComponent();

            //Itens do ComboBox
            cbPrioridade.Items.Add("Normal");
            cbPrioridade.Items.Add("Urgente");
            cbPrioridade.Items.Add("Critico");

            cbPrioridade.SelectedIndex = 0;
        }

        private void txtChamado_Click(object sender, EventArgs e)
        {
            txtChamado.Clear();
        }

        private void txtChamado_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtChamado.Text))
            {
                txtChamado.Text = "descreva um breve resumo aqui...";
            }
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            // Verifica se a descrição está preenchida
            if (string.IsNullOrWhiteSpace(txtChamado.Text) || txtChamado.Text == "descreva seu problema aqui...")
            {
                MessageBox.Show("Por favor, descreva o problema antes de enviar.");
                return;
            }

            // Captura os dados do chamado
            string descricao = txtChamado.Text.Trim();
            DateTime dataAtual = DateTime.Now;
            int usuarioId = SessaoUsuario.UsuarioLogado.Id;

            int categoriaId = await ObterCategoriaViaIA(descricao); //Espera a IA categorizar o chamado e passar o ID
            int prioridadeId = cbPrioridade.SelectedIndex + 1; // Exemplo: Prioridade padrão

            if ( descricao != "" ) { 
                using (DatabaseConnection dbConnection = new DatabaseConnection())
                {
                    var conn = dbConnection.GetConnection();

                    string sql = @"INSERT INTO chamados (cham_data, cham_detalhe, cham_status, usu_id, cat_id, pri_id) 
                           VALUES (@data, @detalhe, 'ABERTO', @usuarioId, @catId, @priId)";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("data", dataAtual.Date); // apenas a data
                        cmd.Parameters.AddWithValue("detalhe", descricao);
                        cmd.Parameters.AddWithValue("usuarioId", usuarioId);
                        cmd.Parameters.AddWithValue("catId", categoriaId);
                        cmd.Parameters.AddWithValue("priId", prioridadeId);
                       // cmd.Parameters.AddWithValue("priId", cbPrioridade.SelectedIndex > -1 ?
                       // (object)cbPrioridade.SelectedValue : DBNull.Value);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Chamado enviado com sucesso!");
                            // Captura os dados do chamado
                            descricao = "";
                            txtChamado.Text = "descreva um breve resumo aqui...";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao enviar chamado: " + ex.Message);
                        }
                    }
                }
            } else {
                MessageBox.Show("Descrição vazia do chamado, tente novamente!");
            }
        }
        private async Task<int> ObterCategoriaViaIA(string descricao)
        {
            var perguntaFormatada = $"Classifique o seguinte chamado como: Software, Hardware, Rede ou Segurança. Responda apenas com o nome da categoria. Texto: {descricao}";
            var json = JsonSerializer.Serialize(new { question = perguntaFormatada });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await new HttpClient().PostAsync("http://localhost:5222/api/deepseek/chamada", content);
                response.EnsureSuccessStatusCode();

                var respostaJson = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Resposta bruta da IA:\n" + respostaJson); // Para debug

                var respostaObj = JsonSerializer.Deserialize<RespostaIA>(respostaJson);

                string categoriaNome = respostaObj?.choices?.FirstOrDefault()?.message?.content?.Trim().ToLower();
                MessageBox.Show($"A IA classificou como: {categoriaNome}");

                int categoriaId;

                if (categoriaNome == "software")
                    categoriaId = 1;
                else if (categoriaNome == "hardware")
                    categoriaId = 2;
                else if (categoriaNome == "rede")
                    categoriaId = 3;
                else if (categoriaNome == "segurança")
                    categoriaId = 4;
                else
                    categoriaId = 1; // padrão

                return categoriaId;
            }
            catch
            {
                return 1; // fallback se erro ocorrer
            }
        }

        private class RespostaIA
        {
            public Choice[] choices { get; set; }
        }

        private class Choice
        {
            public Message message { get; set; }
        }
        private class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }

    }

    public static class SessaoUsuario
    {
        public static Usuario UsuarioLogado { get; set; }
    }

}
