using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using Suporte_TI.Models;

namespace Suporte_TI.Forms
{
    public partial class ChamadoForm : Form
    {
        private string connStr = "Host=localhost;Username=postgres;Password=2005;Database=suporte_ti";

        public ChamadoForm()
        {
            InitializeComponent();
            CarregarChamados();
        }

        private void CarregarChamados()
        {
            flowLayoutChamados.Controls.Clear();

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();

                string sql = @"SELECT c.cham_id, c.cham_data, c.cham_detalhe, c.cham_status, p.pri_nome
                             FROM chamados c
                             JOIN prioridades p ON c.pri_id = p.pri_id
                             WHERE c.usu_id = @usuId AND c.cham_status = 'ABERTO'
                             ORDER BY 
                             CASE p.pri_nome
                                WHEN 'Crítico' THEN 1
                                WHEN 'Urgente' THEN 2
                                WHEN 'Normal' THEN 3
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
                            int id = reader.GetInt32(0);
                            DateTime data = reader.GetDateTime(1);
                            string detalhe = reader.GetString(2);
                            string status = reader.GetString(3);
                            string prioridade = reader.GetString(4);

                            flowLayoutChamados.Controls.Add(CriarCartaoChamado(id, data, detalhe, status, prioridade));
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

        private Panel CriarCartaoChamado(int id, DateTime data, string detalhe, string status, string prioridade)
        {
            var panel = new Panel
            {
                Width = 500,
                Height = 120,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(10)
            };

            var lblId = new Label
            {
                Text = $"Chamado #{id} - {data:dd/MM/yyyy}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            var lblPrioridade = new Label
            {
                Text = $"Prioridade: {prioridade}",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.DarkRed,
                Location = new Point(10, 30),
                AutoSize = true
            };

            var lblDetalhe = new Label
            {
                Text = detalhe.Length > 100 ? detalhe.Substring(0, 100) + "..." : detalhe,
                Location = new Point(10, 50),
                Size = new Size(350, 40)
            };

            var btnAbrir = new Button
            {
                Text = "Abrir Chat",
                Location = new Point(370, 40),
                Size = new Size(100, 30)
            };
            btnAbrir.Click += (s, e) =>
            {
                ChatChamado chatForm = new ChatChamado(id);
                chatForm.TopLevel = false;
                chatForm.FormBorderStyle = FormBorderStyle.None;
                chatForm.Dock = DockStyle.Fill;

                var parentForm = this.Parent as Panel;
                parentForm.Controls.Clear();
                parentForm.Controls.Add(chatForm);
                chatForm.Show();
            };

            panel.Controls.Add(lblId);
            panel.Controls.Add(lblPrioridade);
            panel.Controls.Add(lblDetalhe);
            panel.Controls.Add(btnAbrir);

            return panel;
        }

    }
}
