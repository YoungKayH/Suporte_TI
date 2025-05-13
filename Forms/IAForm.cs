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
using System.Text.Json;
using Npgsql;
using Suporte_TI.Data;
using System.Data.Common;

namespace Suporte_TI.Forms
{
    public partial class IAForm : Form
    {
        private TextBox txtPergunta;
        private RichTextBox txtResposta;
        private Button btnEnviar;
        private Button btnFeedback;
        private Label lblTitulo;
        private Button btnLimparcampos;
        int usuarioLogadoId = SessaoUsuario.UsuarioLogado.Id;

        private readonly HttpClient _httpClient = new HttpClient();
        private const string ApiUrl = "http://localhost:5222/api/deepseek/chamada";

        public IAForm()
        {
            this.Text = "IA Assistente";
            this.BackColor = Color.White;
            this.Size = new Size(600, 400);

            lblTitulo = new Label()
            {
                Text = "Assistente de IA",
                Font = new Font("Century Gothic", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtPergunta = new TextBox()
            {
                Location = new Point(20, 60),
                Size = new Size(400, 30),
                Font = new Font("Century Gothic", 10)
            };

            btnEnviar = new Button()
            {
                Text = "Enviar",
                Location = new Point(440, 60),
                Size = new Size(100, 30)
            };
            btnEnviar.Click += BtnEnviar_Click;

            txtResposta = new RichTextBox()
            {
                Location = new Point(20, 110),
                Size = new Size(520, 180),
                Font = new Font("Century Gothic", 10),
                ReadOnly = true
            };

            btnFeedback = new Button()
            {
                Text = "Foi útil?",
                Location = new Point(20, 310),
                Size = new Size(100, 30),
                Font = new Font("Century Gothic", 10)
            };
            btnFeedback.Click += BtnFeedback_Click;

            btnLimparcampos = new Button()
            {
                Text = "Limpar campos",
                Location = new Point(440, 310), // Alinhado à direita
                Size = new Size(100, 30),
                Font = new Font("Century Gothic", 10)
            };
            btnLimparcampos.Click += btnLimparcampos_Click;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(txtPergunta);
            this.Controls.Add(btnEnviar);
            this.Controls.Add(txtResposta);
            this.Controls.Add(btnFeedback);
            this.Controls.Add(btnLimparcampos);
        }

        private async void BtnEnviar_Click(object sender, EventArgs e)
        {
            string pergunta = txtPergunta.Text.Trim();
            if (string.IsNullOrWhiteSpace(pergunta))
            {
                MessageBox.Show("Digite uma pergunta.");
                return;
            }

            var json = JsonSerializer.Serialize(new { question = pergunta });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(ApiUrl, content);
                response.EnsureSuccessStatusCode();

                var respostaJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine(respostaJson);  // Debug

                // Desserializa o JSON para um objeto dinâmico
                //dynamic resposta = Newtonsoft.Json.JsonConvert.DeserializeObject(respostaJson);

                var respostaObj = JsonSerializer.Deserialize<RespostaIA>(respostaJson);
                string mensagem = respostaObj?.choices?.FirstOrDefault()?.message?.content ?? "Sem resposta.";

                // Extrai a mensagem do JSON (considerando a estrutura fornecida)
                //string mensagem = resposta?.message ?? "Sem resposta.";

                // Atualiza a UI na thread principal (se necessário)
                if (txtResposta.InvokeRequired)
                {
                    txtResposta.Invoke(new Action(() => txtResposta.Text = mensagem));
                }
                else
                {
                    txtResposta.Text = mensagem;
                }

                RegistrarUsoIA(pergunta);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void BtnFeedback_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("A resposta foi útil?", "Feedback", MessageBoxButtons.YesNo);
            bool foiUtil = resultado == DialogResult.Yes;
            LimparCampos();
            RegistrarFeedback(foiUtil);
        }

        private void RegistrarUsoIA(string pergunta)
        {
            //inserir no banco: INSERT INTO uso_ia (pergunta, resposta, data_uso) VALUES (...)
            using (DatabaseConnection dbConnection = new DatabaseConnection())
            {
                var conn = dbConnection.GetConnection();

                var cmd = new NpgsqlCommand(
            "INSERT INTO interacoes_chamado (usu_id, int_pergunta, uso_ia) VALUES (@usuario, @pergunta, TRUE)", conn);

                cmd.Parameters.AddWithValue("@usuario", SessaoUsuario.UsuarioLogado.Id);
                cmd.Parameters.AddWithValue("@pergunta", pergunta);
                cmd.ExecuteNonQuery();
            }
        }

        private void RegistrarFeedback(bool foiUtil)
        {
            // UPDATE na tabela de uso_ia ou INSERT em feedbacks

            using (DatabaseConnection dbConnection = new DatabaseConnection())
            {
                var conn = dbConnection.GetConnection();

                var cmd = new NpgsqlCommand(
                @"UPDATE interacoes_chamado
                SET int_foi_util = @foiUtil
                WHERE int_id = (
                SELECT int_id
                FROM interacoes_chamado
                WHERE usu_id = @usuario AND uso_ia = TRUE
                ORDER BY int_data DESC
                LIMIT 1)", conn);

                cmd.Parameters.AddWithValue("@foiUtil", foiUtil);
                cmd.Parameters.AddWithValue("@usuario", SessaoUsuario.UsuarioLogado.Id);
                cmd.ExecuteNonQuery();
            }
        }

        private void LimparCampos()
        {
            txtResposta.Clear();
            txtPergunta.Clear();
        }

        private void btnLimparcampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
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

        private void IAForm_Load(object sender, EventArgs e)
        {

        }
    }
}
