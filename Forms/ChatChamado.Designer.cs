namespace Suporte_TI.Forms
{
    partial class ChatChamado
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
            this.listMensagens = new System.Windows.Forms.ListBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.lblTituloChamado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listMensagens
            // 
            this.listMensagens.FormattingEnabled = true;
            this.listMensagens.ItemHeight = 16;
            this.listMensagens.Location = new System.Drawing.Point(12, 87);
            this.listMensagens.Name = "listMensagens";
            this.listMensagens.Size = new System.Drawing.Size(347, 324);
            this.listMensagens.TabIndex = 0;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(450, 351);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(105, 42);
            this.btnEnviar.TabIndex = 1;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtMensagem
            // 
            this.txtMensagem.Location = new System.Drawing.Point(410, 281);
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(192, 22);
            this.txtMensagem.TabIndex = 2;
            // 
            // lblTituloChamado
            // 
            this.lblTituloChamado.AutoSize = true;
            this.lblTituloChamado.Location = new System.Drawing.Point(372, 35);
            this.lblTituloChamado.Name = "lblTituloChamado";
            this.lblTituloChamado.Size = new System.Drawing.Size(44, 16);
            this.lblTituloChamado.TabIndex = 3;
            this.lblTituloChamado.Text = "label1";
            // 
            // ChatChamado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTituloChamado);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.listMensagens);
            this.Name = "ChatChamado";
            this.Text = "ChatChamado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listMensagens;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.Label lblTituloChamado;
    }
}