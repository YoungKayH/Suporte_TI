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

            string usuarioCadastrado = "a";
            string senhaCadastrada = "1";

            if (nomeDigitado.Equals(usuarioCadastrado) &&  senhaDigitada.Equals(senhaCadastrada)) 
            {
                MessageBox.Show("Nome cadastrado: " + nomeDigitado);
                Chamado chamado = new Chamado();
                chamado.Show();
                this.Hide(); // ou this.Hide() se não quiser fechar
                
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
                MessageBox.Show("Senha incorreta!");
            }
            
        }
    }
}
//nomeDigitado != null senhaDigitada != null &&
