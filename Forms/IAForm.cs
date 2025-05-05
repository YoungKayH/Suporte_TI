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

namespace Suporte_TI.Forms
{
    public partial class IAForm : Form
    {
        private TextBox txtPergunta;
        private RichTextBox txtResposta;
        private Button btnEnviar;
        private Button btnFeedback;
        private Label lblTitulo;

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
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtPergunta = new TextBox()
            {
                Location = new Point(20, 60),
                Size = new Size(400, 30),
                Font = new Font("Segoe UI", 10)
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
                Font = new Font("Segoe UI", 10),
                ReadOnly = true
            };

            btnFeedback = new Button()
            {
                Text = "Foi útil?",
                Location = new Point(20, 310),
                Size = new Size(100, 30)
            };
            btnFeedback.Click += BtnFeedback_Click;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(txtPergunta);
            this.Controls.Add(btnEnviar);
            this.Controls.Add(txtResposta);
            this.Controls.Add(btnFeedback);
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
                var resposta = JsonSerializer.Deserialize<RespostaIA>(respostaJson);
                Console.WriteLine(respostaJson);  // Adicione para ver a resposta no console ou uma MessageBox para debug

                txtResposta.Text = resposta?.choices?[0]?.message?.content ?? "Sem resposta.";

                RegistrarUsoIA(pergunta, txtResposta.Text);
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
            RegistrarFeedback(foiUtil);
        }

        private void RegistrarUsoIA(string pergunta, string resposta)
        {
            // Aqui você pode inserir no banco: INSERT INTO uso_ia (pergunta, resposta, data_uso) VALUES (...)
        }

        private void RegistrarFeedback(bool foiUtil)
        {
            // UPDATE na tabela de uso_ia ou INSERT em feedbacks
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
}
