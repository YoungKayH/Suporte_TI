using System;
using System.Collections.Generic;
using System.Net.Http;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Suporte_TI
{
    public partial class Chamado : Form
    {
        public Chamado()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = "http://127.0.0.1:5000/prever";

            // Captura o texto digitado pelo usuário no TextBox
            string chamadoTexto = txtChamado.Text;

            // Verifica se está vazio
            if (string.IsNullOrWhiteSpace(chamadoTexto))
            {
                MessageBox.Show("Digite um chamado antes de enviar.");
                return;
            }

            var chamado = new { chamado = chamadoTexto };
            string json = JsonConvert.SerializeObject(chamado);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string resposta = await response.Content.ReadAsStringAsync();

                    // Mostra a resposta da API no label
                    lblResposta.Text = "Resposta da API: " + resposta;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar com a API: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Close(); // ou this.Hide() se não quiser fechar
        }
    }
}
