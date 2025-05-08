namespace Suporte_TI.Forms
{
    partial class ChamadoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutChamados = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutChamados
            // 
            this.flowLayoutChamados.AutoScroll = true;
            this.flowLayoutChamados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutChamados.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutChamados.Name = "flowLayoutChamados";
            this.flowLayoutChamados.Size = new System.Drawing.Size(800, 450);
            this.flowLayoutChamados.TabIndex = 0;
            this.flowLayoutChamados.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutChamados_Paint);
            // 
            // ChamadoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutChamados);
            this.Name = "ChamadoForm";
            this.Text = "ChamadoForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutChamados;
    }
}