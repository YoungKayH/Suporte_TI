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

                string sql = @"SELECT cham_id, cham_data, cham_detalhe, cham_status 
                               FROM chamados 
                               WHERE usu_id = @usuId AND cham_status = 'ABERTO'
                               ORDER BY cham_data DESC";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("usuId", SessaoUsuario.UsuarioLogado.Id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            DateTime data = reader.GetDateTime(1);
                            string detalhe = reader.GetString(2);
                            string status = reader.GetString(3);

                            flowLayoutChamados.Controls.Add(CriarCartaoChamado(id, data, detalhe, status));
                        }
                    }
                }
            }
        }

        private Panel CriarCartaoChamado(int id, DateTime data, string detalhe, string status)
        {
            var panel = new Panel
            {
                Width = 500,
                Height = 100,
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

            var lblDetalhe = new Label
            {
                Text = detalhe.Length > 100 ? detalhe.Substring(0, 100) + "..." : detalhe,
                Location = new Point(10, 35),
                Size = new Size(350, 40)
            };

            var btnAbrir = new Button
            {
                Text = "Abrir Chat",
                Location = new Point(370, 30),
                Size = new Size(100, 30)
            };
            btnAbrir.Click += (s, e) =>
            {
                ChatChamado chatForm = new ChatChamado(id);
                chatForm.TopLevel = false;
                chatForm.FormBorderStyle = FormBorderStyle.None;
                chatForm.Dock = DockStyle.Fill;

                // Se estiver usando um Panel central (como em MDI)
                var parentForm = this.Parent as Panel;
                parentForm.Controls.Clear();
                parentForm.Controls.Add(chatForm);
                chatForm.Show();
            };

            panel.Controls.Add(lblId);
            panel.Controls.Add(lblDetalhe);
            panel.Controls.Add(btnAbrir);

            return panel;
        }
    }
}
