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
using Suporte_TI.Forms;

namespace Suporte_TI
{
    

    public partial class Menu : Form
    {
        private Form formularioAtivo = null;
        public Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
        
        private void btnPainel_Click(object sender, EventArgs e)
        {
            AbrirFormularioFilho(new Painel());
        }
        private void AbrirFormularioFilho(Form formularioFilho)
        {
            if (formularioAtivo != null)
            {
                formularioAtivo.Close();
            }

            formularioAtivo = formularioFilho;
            formularioFilho.TopLevel = false;
            formularioFilho.FormBorderStyle = FormBorderStyle.None;
            formularioFilho.Dock = DockStyle.Fill;
            panelConteudo.Controls.Add(formularioFilho);
            panelConteudo.Tag = formularioFilho;
            formularioFilho.BringToFront();
            formularioFilho.Show();
        }

        private void btnSeuchamado_Click(object sender, EventArgs e)
        {
            AbrirFormularioFilho(new ChamadoForm());
        }

        private void btnNovochamado_Click(object sender, EventArgs e)
        {
            AbrirFormularioFilho(new NovoChamadoForm());
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            CadastroUsu cad = new CadastroUsu();
            cad.Show();
            this.Hide(); // ou this.Close() se quiser fechar    
        }

        private void btnIA_Click(object sender, EventArgs e)
        {
            IAForm iaForm = new IAForm();
            iaForm.TopLevel = false;
            iaForm.FormBorderStyle = FormBorderStyle.None;
            iaForm.Dock = DockStyle.Fill;

            panelConteudo.Controls.Clear(); // nome correto do painel
            panelConteudo.Controls.Add(iaForm);
            iaForm.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }
    }
}
