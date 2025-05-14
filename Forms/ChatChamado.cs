using Npgsql;
using Suporte_TI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Suporte_TI.Data;
using Newtonsoft.Json;


namespace Suporte_TI.Forms
{
    public partial class ChatChamado : Form
    {
        private int chamadoId;
        public ChatChamado(int id)
        {
            InitializeComponent();
            chamadoId = id;
            lblTituloChamado.Text = $"Chat do Chamado #{chamadoId}";
            if (id != 0)
            {
                CarregarMensagens();
            }
            CarregarMensagens();
        }
        private async void CarregarMensagens()
        {
            listMensagens.Items.Clear();

            // 1. Carrega mensagens do Supabase
            try
            {
                var supabaseApi = new Suporte_TI.Data.SupabaseApi();
                var mensagensSupabase = supabaseApi.ObterMensagens(chamadoId);

                foreach (var msg in mensagensSupabase)
                {
                    //string nomeRemetente = "Usuário ID " + msg.remetente_id;
                    string nomeRemetente = ObterNomeUsuarioPorId(msg.remetente_id);
                    string exibicao = $"[{msg.data_envio:dd/MM/yyyy HH:mm}] {nomeRemetente}: {msg.mensagem}";

                    listMensagens.Items.Add(exibicao);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar Supabase: " + ex.Message);
            }

            using (DatabaseConnection databaseConnection = new DatabaseConnection() )
            {
                var conn = databaseConnection.GetConnection();

                var sql = @"SELECT m.mensagem, u.usu_nome, m.data_envio 
                            FROM mensagens m 
                            JOIN usuarios u ON m.remetente_id = u.usu_id 
                            WHERE cham_id = @chamadoId 
                            ORDER BY m.data_envio";


                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("chamadoId", chamadoId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nome = reader["usu_nome"].ToString();
                            string mensagem = reader["mensagem"].ToString();
                            DateTime data = (DateTime)reader["data_envio"];
                            string exibicao = $"[{data:dd/MM/yyyy HH:mm}] {nome}: {mensagem}";

                            listMensagens.Items.Add(exibicao);
                        }
                    }
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string texto = txtMensagem.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("Digite uma mensagem.");
                return;
            }

            using (DatabaseConnection databaseConnection = new DatabaseConnection())
            {
                var conn = databaseConnection.GetConnection();

                string sql = @"INSERT INTO mensagens (cham_id, remetente_id, mensagem) 
                               VALUES (@chamId, @remetenteId, @mensagem)";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("chamId", chamadoId);
                    cmd.Parameters.AddWithValue("remetenteId", SessaoUsuario.UsuarioLogado.Id);
                    cmd.Parameters.AddWithValue("mensagem", texto);
                    cmd.ExecuteNonQuery();
                }
            }

            txtMensagem.Clear();
            CarregarMensagens();

            try
            {
                var supabaseApi = new Suporte_TI.Data.SupabaseApi();
                var mensagem = new MensagemSupabase
                {
                    cham_id = chamadoId,
                    remetente_id = SessaoUsuario.UsuarioLogado.Id,
                    remetente_nome = ObterNomeUsuarioPorId(SessaoUsuario.UsuarioLogado.Id),
                    mensagem = texto,
                    data_envio = DateTime.Now
                };
                supabaseApi.EnviarMensagem(mensagem);
                //supabaseApi.EnviarMensagem(chamadoId, SessaoUsuario.UsuarioLogado.Id, texto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar mensagem para Supabase: " + ex.Message);
            }

            txtMensagem.Clear();
            CarregarMensagens();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Tem certeza que deseja fechar este chamado?",
                                    "Fechar Chamado",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

            DateTime dataAtual = DateTime.Now; //Captura a data atual pra inserir no BD

            if (resultado == DialogResult.Yes)
            {
                using (DatabaseConnection databaseConnection = new DatabaseConnection())
                {
                    var conn = databaseConnection.GetConnection();  

                    string sql = @"UPDATE chamados 
                           SET cham_status = 'FECHADO', cham_data_fechamento = @data 
                           WHERE cham_id = @id";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", chamadoId);
                        cmd.Parameters.AddWithValue("data", dataAtual.Date);
                        cmd.ExecuteNonQuery();
                    }
                }
                try
                {
                    var supabaseApi = new Suporte_TI.Data.SupabaseApi();
                   // supabaseApi.FecharChamado(chamadoId, dataAtual.Date);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao fechar chamado no Supabase: " + ex.Message);
                }

                MessageBox.Show("Chamado fechado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Fecha o formulário do chat
            }
        }
        private string ObterNomeUsuarioPorId(int usuarioId) // função para obter o nome do usuário
        {
            using (DatabaseConnection databaseConnection = new DatabaseConnection())
            {
                var conn = databaseConnection.GetConnection();
                string sql = "SELECT usu_nome FROM usuarios WHERE usu_id = @id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", usuarioId);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? $"Usuário ID {usuarioId}";
                }
            }  
        }
    }
}
