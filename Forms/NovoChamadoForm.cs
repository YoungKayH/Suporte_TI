using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suporte_TI.Forms
{
    public partial class NovoChamadoForm : Form
    {
        public NovoChamadoForm()
        {
            InitializeComponent();
        }

        private void txtChamado_Click(object sender, EventArgs e)
        {
            txtChamado.Clear();
        }

        private void txtChamado_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtChamado.Text))
            {
                txtChamado.Text = "descreva seu problema aqui...";
            }
        }
    }
}
