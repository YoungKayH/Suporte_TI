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

namespace Suporte_TI.Forms
{
    public partial class ChatChamado : Form
    {
        private int chamadoId;
        private string connStr = "Host=localhost;Username=postgres;Password=2005;Database=chamados";

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
        private void CarregarMensagens()
        {
            listMensagens.Items.Clear();

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

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

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

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
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();

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

                MessageBox.Show("Chamado fechado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Fecha o formulário do chat
            }
        }

        private void lblTituloChamado_Click(object sender, EventArgs e)
        {

        }

        private void ChatChamado_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
