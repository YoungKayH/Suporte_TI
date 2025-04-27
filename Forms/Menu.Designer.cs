namespace Suporte_TI
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPainel = new System.Windows.Forms.Button();
            this.btnSeuchamado = new System.Windows.Forms.Button();
            this.btnNovochamado = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.panelConteudo = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 95);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel2.Location = new System.Drawing.Point(260, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 72);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel3.Controls.Add(this.btnSair);
            this.panel3.Controls.Add(this.btnNovochamado);
            this.panel3.Controls.Add(this.btnSeuchamado);
            this.panel3.Controls.Add(this.btnPainel);
            this.panel3.Location = new System.Drawing.Point(2, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 359);
            this.panel3.TabIndex = 6;
            // 
            // btnPainel
            // 
            this.btnPainel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPainel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(195)))), ((int)(((byte)(247)))));
            this.btnPainel.Image = ((System.Drawing.Image)(resources.GetObject("btnPainel.Image")));
            this.btnPainel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPainel.Location = new System.Drawing.Point(0, 0);
            this.btnPainel.Name = "btnPainel";
            this.btnPainel.Size = new System.Drawing.Size(260, 85);
            this.btnPainel.TabIndex = 0;
            this.btnPainel.Text = "Painel";
            this.btnPainel.UseVisualStyleBackColor = true;
            this.btnPainel.Click += new System.EventHandler(this.btnPainel_Click);
            // 
            // btnSeuchamado
            // 
            this.btnSeuchamado.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeuchamado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(195)))), ((int)(((byte)(247)))));
            this.btnSeuchamado.Image = ((System.Drawing.Image)(resources.GetObject("btnSeuchamado.Image")));
            this.btnSeuchamado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeuchamado.Location = new System.Drawing.Point(0, 91);
            this.btnSeuchamado.Name = "btnSeuchamado";
            this.btnSeuchamado.Size = new System.Drawing.Size(260, 89);
            this.btnSeuchamado.TabIndex = 1;
            this.btnSeuchamado.Text = "Seus chamados";
            this.btnSeuchamado.UseVisualStyleBackColor = true;
            this.btnSeuchamado.Click += new System.EventHandler(this.btnSeuchamado_Click);
            // 
            // btnNovochamado
            // 
            this.btnNovochamado.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovochamado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(195)))), ((int)(((byte)(247)))));
            this.btnNovochamado.Image = ((System.Drawing.Image)(resources.GetObject("btnNovochamado.Image")));
            this.btnNovochamado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovochamado.Location = new System.Drawing.Point(0, 186);
            this.btnNovochamado.Name = "btnNovochamado";
            this.btnNovochamado.Size = new System.Drawing.Size(260, 80);
            this.btnNovochamado.TabIndex = 2;
            this.btnNovochamado.Text = "Novo chamado";
            this.btnNovochamado.UseVisualStyleBackColor = true;
            this.btnNovochamado.Click += new System.EventHandler(this.btnNovochamado_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(195)))), ((int)(((byte)(247)))));
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(0, 272);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(260, 85);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panelConteudo
            // 
            this.panelConteudo.Location = new System.Drawing.Point(260, 66);
            this.panelConteudo.Name = "panelConteudo";
            this.panelConteudo.Size = new System.Drawing.Size(776, 458);
            this.panelConteudo.TabIndex = 7;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1040, 536);
            this.Controls.Add(this.panelConteudo);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Menu";
            this.Text = "Suporte";
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPainel;
        private System.Windows.Forms.Button btnSeuchamado;
        private System.Windows.Forms.Button btnNovochamado;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panelConteudo;
    }
}