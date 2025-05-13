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
    public partial class SplashScreen : Form
    {
        private Timer progressTimer;
        public SplashScreen()
        {
            InitializeComponent();
            this.ClientSize = pictureBox1.Size; // Ajusta o tamanho do formulário ao tamanho da PictureBox

            progressTimer = new Timer();
            progressTimer.Interval = 50; // intervalo em ms
            progressTimer.Tick += ProgressTimer_Tick;

            // Configura o timer
            splashTimer = new Timer();
            splashTimer.Interval = 3000; // 3 segundos
            splashTimer.Tick += SplashTimer_Tick;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None; // remove borda
            this.TopMost = true; // fica em cima das outras janelas
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            splashTimer.Start(); // começa a contagem ao abrir
            progressBar1.Value = 0;
            progressTimer.Start();
        }
        private void SplashTimer_Tick(object sender, EventArgs e)
        {
            splashTimer.Stop();
            this.Close(); // Fecha o splash
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 2; // aumenta o valor da barra
            }
            else
            {
                progressTimer.Stop();
                this.Close(); // Fecha o splash
            }
        }
    }
}
