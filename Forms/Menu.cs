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
    }
}