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
            this.btnIA = new System.Windows.Forms.Button();
            this.btnNovochamado = new System.Windows.Forms.Button();
            this.btnSeuchamado = new System.Windows.Forms.Button();
            this.panelConteudo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIA
            // 
            this.btnIA.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIA.BackgroundImage")));
            this.btnIA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIA.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIA.ForeColor = System.Drawing.Color.White;
            this.btnIA.Location = new System.Drawing.Point(23, 353);
            this.btnIA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIA.Name = "btnIA";
            this.btnIA.Size = new System.Drawing.Size(248, 69);
            this.btnIA.TabIndex = 4;
            this.btnIA.Text = "Interagir com a IA";
            this.btnIA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIA.UseVisualStyleBackColor = true;
            this.btnIA.Click += new System.EventHandler(this.btnIA_Click);
            // 
            // btnNovochamado
            // 
            this.btnNovochamado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNovochamado.BackgroundImage")));
            this.btnNovochamado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNovochamado.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovochamado.ForeColor = System.Drawing.Color.White;
            this.btnNovochamado.Location = new System.Drawing.Point(28, 124);
            this.btnNovochamado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNovochamado.Name = "btnNovochamado";
            this.btnNovochamado.Size = new System.Drawing.Size(243, 72);
            this.btnNovochamado.TabIndex = 2;
            this.btnNovochamado.Text = "Novo chamado";
            this.btnNovochamado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovochamado.UseVisualStyleBackColor = true;
            this.btnNovochamado.Click += new System.EventHandler(this.btnNovochamado_Click);
            // 
            // btnSeuchamado
            // 
            this.btnSeuchamado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSeuchamado.BackgroundImage")));
            this.btnSeuchamado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSeuchamado.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeuchamado.ForeColor = System.Drawing.Color.White;
            this.btnSeuchamado.Location = new System.Drawing.Point(25, 239);
            this.btnSeuchamado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSeuchamado.Name = "btnSeuchamado";
            this.btnSeuchamado.Size = new System.Drawing.Size(246, 71);
            this.btnSeuchamado.TabIndex = 1;
            this.btnSeuchamado.Text = "Seus chamados";
            this.btnSeuchamado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeuchamado.UseVisualStyleBackColor = true;
            this.btnSeuchamado.Click += new System.EventHandler(this.btnSeuchamado_Click);
            // 
            // panelConteudo
            // 
            this.panelConteudo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(23)))), ((int)(((byte)(57)))));
            this.panelConteudo.Location = new System.Drawing.Point(388, 15);
            this.panelConteudo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelConteudo.Name = "panelConteudo";
            this.panelConteudo.Size = new System.Drawing.Size(1085, 751);
            this.panelConteudo.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-7, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1511, 828);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1632, 753);
            this.Controls.Add(this.panelConteudo);
            this.Controls.Add(this.btnIA);
            this.Controls.Add(this.btnNovochamado);
            this.Controls.Add(this.btnSeuchamado);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suporte";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSeuchamado;
        private System.Windows.Forms.Button btnNovochamado;
        private System.Windows.Forms.Button btnIA;
        private System.Windows.Forms.Panel panelConteudo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}