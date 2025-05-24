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
    public partial class CartaoChamado : UserControl
    {
        public event EventHandler BotaoAbrirClicado;
        public CartaoChamado()
        {
            InitializeComponent();
        }
        public void ConfigurarChamado(int id, DateTime data, string detalhe, string prioridade)
        {
            lblTitulo.Text = $"Chamado #{id} - {data:dd/MM/yyyy}";
            lblPrioridade.Text = prioridade.ToUpper();
            lblDetalhe.Text = detalhe.Length > 150 ? detalhe.Substring(0, 150) + "..." : detalhe;

            // Configura cor baseado na prioridade
            switch (prioridade.ToLower())
            {
                case "alta":
                    lblPrioridade.BackColor = Color.FromArgb(255, 105, 97);
                    break;
                case "média":
                    lblPrioridade.BackColor = Color.FromArgb(255, 179, 71);
                    break;
                case "baixa":
                    lblPrioridade.BackColor = Color.FromArgb(119, 221, 119);
                    break;
                default:
                    lblPrioridade.BackColor = Color.Gray;
                    break;
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            BotaoAbrirClicado?.Invoke(this, e);
        }
    }
}
