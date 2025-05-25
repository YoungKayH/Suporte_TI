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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnIA = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnNovochamado = new System.Windows.Forms.Button();
            this.btnSeuchamado = new System.Windows.Forms.Button();
            this.btnPainel = new System.Windows.Forms.Button();
            this.panelConteudo = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 95);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel2.Controls.Add(this.btnCadastro);
            this.panel2.Location = new System.Drawing.Point(260, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 72);
            this.panel2.TabIndex = 5;
            // 
            // btnCadastro
            // 
            this.btnCadastro.Location = new System.Drawing.Point(8, 12);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(202, 51);
            this.btnCadastro.TabIndex = 0;
            this.btnCadastro.Text = "Deletar usuario";
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Visible = false;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel3.Controls.Add(this.btnIA);
            this.panel3.Controls.Add(this.btnSair);
            this.panel3.Controls.Add(this.btnNovochamado);
            this.panel3.Controls.Add(this.btnSeuchamado);
            this.panel3.Controls.Add(this.btnPainel);
            this.panel3.Location = new System.Drawing.Point(2, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 444);
            this.panel3.TabIndex = 6;
            // 
            // btnIA
            // 
            this.btnIA.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(195)))), ((int)(((byte)(247)))));
            this.btnIA.Image = ((System.Drawing.Image)(resources.GetObject("btnIA.Image")));
            this.btnIA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIA.Location = new System.Drawing.Point(-3, 253);
            this.btnIA.Name = "btnIA";
            this.btnIA.Size = new System.Drawing.Size(263, 85);
            this.btnIA.TabIndex = 4;
            this.btnIA.Text = "Conversar com a IA";
            this.btnIA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIA.UseVisualStyleBackColor = true;
            this.btnIA.Click += new System.EventHandler(this.btnIA_Click);
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(195)))), ((int)(((byte)(247)))));
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(-6, 331);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(266, 91);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnNovochamado
            // 
            this.btnNovochamado.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovochamado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(195)))), ((int)(((byte)(247)))));
            this.btnNovochamado.Image = ((System.Drawing.Image)(resources.GetObject("btnNovochamado.Image")));
            this.btnNovochamado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovochamado.Location = new System.Drawing.Point(0, 164);
            this.btnNovochamado.Name = "btnNovochamado";
            this.btnNovochamado.Size = new System.Drawing.Size(260, 92);
            this.btnNovochamado.TabIndex = 2;
            this.btnNovochamado.Text = "Novo chamado";
            this.btnNovochamado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovochamado.UseVisualStyleBackColor = true;
            this.btnNovochamado.Click += new System.EventHandler(this.btnNovochamado_Click);
            // 
            // btnSeuchamado
            // 
            this.btnSeuchamado.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeuchamado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(195)))), ((int)(((byte)(247)))));
            this.btnSeuchamado.Image = ((System.Drawing.Image)(resources.GetObject("btnSeuchamado.Image")));
            this.btnSeuchamado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeuchamado.Location = new System.Drawing.Point(0, 86);
            this.btnSeuchamado.Name = "btnSeuchamado";
            this.btnSeuchamado.Size = new System.Drawing.Size(260, 88);
            this.btnSeuchamado.TabIndex = 1;
            this.btnSeuchamado.Text = "Seus chamados";
            this.btnSeuchamado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeuchamado.UseVisualStyleBackColor = true;
            this.btnSeuchamado.Click += new System.EventHandler(this.btnSeuchamado_Click);
            // 
            // btnPainel
            // 
            this.btnPainel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPainel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(195)))), ((int)(((byte)(247)))));
            this.btnPainel.Image = ((System.Drawing.Image)(resources.GetObject("btnPainel.Image")));
            this.btnPainel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPainel.Location = new System.Drawing.Point(0, 0);
            this.btnPainel.Name = "btnPainel";
            this.btnPainel.Size = new System.Drawing.Size(260, 89);
            this.btnPainel.TabIndex = 0;
            this.btnPainel.Text = "Deletar Usuarios";
            this.btnPainel.UseVisualStyleBackColor = true;
            this.btnPainel.Click += new System.EventHandler(this.btnPainel_Click);
            // 
            // panelConteudo
            // 
            this.panelConteudo.Location = new System.Drawing.Point(260, 66);
            this.panelConteudo.Name = "panelConteudo";
            this.panelConteudo.Size = new System.Drawing.Size(780, 470);
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
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnIA;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCadastro;
    }
}