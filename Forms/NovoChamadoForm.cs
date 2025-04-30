using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Suporte_TI.Models;


namespace Suporte_TI.Forms
{
    public partial class NovoChamadoForm : Form
    {
        public NovoChamadoForm()
        {
            InitializeComponent();
        }

        private void txtChamado_Click(object sender, EventArgs e)
        {
            txtChamado.Clear();
        }

        private void txtChamado_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtChamado.Text))
            {
                txtChamado.Text = "descreva seu problema aqui...";
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
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

            // Ajuste conforme o ID padrão das categorias e prioridades
            int categoriaId = 1; // Exemplo: Categoria padrão
            int prioridadeId = 1; // Exemplo: Prioridade padrão

            // Conexão com PostgreSQL
            string connStr = "Host=localhost;Username=postgres;Password=2005;Database=suporte_ti";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string sql = @"INSERT INTO chamados (cham_data, cham_detalhe, cham_status, usu_id, cat_id, pri_id) 
                       VALUES (@data, @detalhe, 'ABERTO', @usuarioId, @catId, @priId)";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("data", dataAtual.Date); // apenas a data
                    cmd.Parameters.AddWithValue("detalhe", descricao);
                    cmd.Parameters.AddWithValue("usuarioId", usuarioId);
                    cmd.Parameters.AddWithValue("catId", categoriaId);
                    cmd.Parameters.AddWithValue("priId", prioridadeId);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Chamado enviado com sucesso!");
                        txtChamado.Text = "descreva seu problema aqui...";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao enviar chamado: " + ex.Message);
                    }
                }
            }
        }
    }
    public static class SessaoUsuario
    {
        public static Usuario UsuarioLogado { get; set; }
    }

}
