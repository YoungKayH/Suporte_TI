using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using Suporte_TI.Data;
using Suporte_TI.Models;

namespace Suporte_TI.Forms
{
    public partial class ChamadoForm : Form
    {

        public ChamadoForm()
        {
            InitializeComponent();
            CarregarChamados();
        }

        private void CarregarChamados()
        {
            flowLayoutChamados.Controls.Clear();
            
                using (DatabaseConnection dbConnection = new DatabaseConnection())
                {
                var conn = dbConnection.GetConnection();

                string sql = @"SELECT c.cham_id, c.cham_data, c.cham_detalhe, c.cham_status, p.pri_nome
                             FROM chamados c
                             JOIN prioridades p ON c.pri_id = p.pri_id
                             WHERE c.usu_id = @usuId AND c.cham_status = 'ABERTO'
                             ORDER BY 
                             CASE p.pri_nome
                                WHEN 'Alta' THEN 1
                                WHEN 'Média' THEN 2
                                WHEN 'Baixa' THEN 3
                                ELSE 4
                             END,
                            c.cham_data DESC";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("usuId", SessaoUsuario.UsuarioLogado.Id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        bool temChamados = false;

                        while (reader.Read())
                        {
                            temChamados = true;
                            int id = reader.GetInt32(0);
                            DateTime data = reader.GetDateTime(1);
                            string detalhe = reader.GetString(2);
                            string status = reader.GetString(3);
                           // string prioridade = reader.GetString(4);
                            string prioridade = reader.GetString(4).Trim();

                            var cartao = new CartaoChamado();
                            cartao.ConfigurarChamado(id, data, detalhe, prioridade);
                            cartao.BotaoAbrirClicado += (s, e) => AbrirChat(id);

                            flowLayoutChamados.Controls.Add(cartao);
                        }
                        if (!temChamados)
                        {
                            var lblVazio = new Label
                            {
                                Text = "Nenhum chamado aberto.",
                                AutoSize = true,
                                Font = new Font("Segoe UI", 12, FontStyle.Italic),
                                ForeColor = Color.Gray,
                                Margin = new Padding(10),
                                Padding = new Padding(10)
                            };
                            flowLayoutChamados.Controls.Add(lblVazio);
                        }
                    }
                }
            }
        }
        private void AbrirChat(int idChamado)
        {
            ChatChamado chatForm = new ChatChamado(idChamado);
            chatForm.TopLevel = false;
            chatForm.FormBorderStyle = FormBorderStyle.None;
            chatForm.Dock = DockStyle.Fill;

            var parentForm = this.Parent as Panel;
            parentForm?.Controls.Clear();
            parentForm?.Controls.Add(chatForm);
            chatForm.Show();
        }

        private void flowLayoutChamados_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
