namespace Suporte_TI.Forms
{
    partial class CartaoChamado
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblPrioridade = new System.Windows.Forms.Label();
            this.lblDetalhe = new System.Windows.Forms.Label();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(171, 16);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Chamado #000 - 00/00/0000";
            // 
            // lblPrioridade
            // 
            this.lblPrioridade.AutoSize = true;
            this.lblPrioridade.BackColor = System.Drawing.Color.DarkRed;
            this.lblPrioridade.Location = new System.Drawing.Point(20, 40);
            this.lblPrioridade.Name = "lblPrioridade";
            this.lblPrioridade.Size = new System.Drawing.Size(41, 16);
            this.lblPrioridade.TabIndex = 1;
            this.lblPrioridade.Text = "ALTA";
            this.lblPrioridade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDetalhe
            // 
            this.lblDetalhe.AutoSize = true;
            this.lblDetalhe.Location = new System.Drawing.Point(15, 65);
            this.lblDetalhe.Name = "lblDetalhe";
            this.lblDetalhe.Size = new System.Drawing.Size(152, 16);
            this.lblDetalhe.TabIndex = 2;
            this.lblDetalhe.Text = " Detalhes do chamado...";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Location = new System.Drawing.Point(316, 115);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(150, 30);
            this.btnAbrir.TabIndex = 3;
            this.btnAbrir.Text = "Abrir Chamado";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // CartaoChamado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.lblDetalhe);
            this.Controls.Add(this.lblPrioridade);
            this.Controls.Add(this.lblTitulo);
            this.Name = "CartaoChamado";
            this.Size = new System.Drawing.Size(498, 148);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion 

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPrioridade;
        private System.Windows.Forms.Label lblDetalhe;
        private System.Windows.Forms.Button btnAbrir;
    }
}
