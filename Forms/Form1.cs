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

namespace Suporte_TI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nomeDigitado = txtLogin.Text;
            string senhaDigitada = txtSenha.Text;

            Usuario usuarioCadastrado = new Usuario
            {
                Login = "a",
                Senha = "1",
                Nivel = 1 // Se quiser usar nível depois para gerente ou normal
            };

            //string usuarioCadastrado = "a";
            //string senhaCadastrada = "1";

            if (nomeDigitado == usuarioCadastrado.Login && senhaDigitada == usuarioCadastrado.Senha)
            {
                Menu chamado = new Menu();
                chamado.Show();
                this.Hide(); // ou this.Close() se quiser fechar
                
            }
            else if (string.IsNullOrWhiteSpace(nomeDigitado) || string.IsNullOrWhiteSpace(senhaDigitada))
            {
                MessageBox.Show("Por favor insira os dados de login!",
                                "Campos sem dados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Senha ou login incorretos!",
                        "Erro de Login",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
    }
}
