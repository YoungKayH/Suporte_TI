namespace Suporte_TI.Forms
{
    partial class NovoChamadoForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBasico = new System.Windows.Forms.CheckBox();
            this.checkImportante = new System.Windows.Forms.CheckBox();
            this.checkUrgente = new System.Windows.Forms.CheckBox();
            this.txtChamado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(495, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(293, 22);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prioridade do Problema";
            // 
            // checkBasico
            // 
            this.checkBasico.AutoSize = true;
            this.checkBasico.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBasico.Location = new System.Drawing.Point(15, 49);
            this.checkBasico.Name = "checkBasico";
            this.checkBasico.Size = new System.Drawing.Size(86, 25);
            this.checkBasico.TabIndex = 3;
            this.checkBasico.Text = "Básico";
            this.checkBasico.UseVisualStyleBackColor = true;
            // 
            // checkImportante
            // 
            this.checkImportante.AutoSize = true;
            this.checkImportante.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkImportante.Location = new System.Drawing.Point(15, 80);
            this.checkImportante.Name = "checkImportante";
            this.checkImportante.Size = new System.Drawing.Size(127, 25);
            this.checkImportante.TabIndex = 4;
            this.checkImportante.Text = "Importante";
            this.checkImportante.UseVisualStyleBackColor = true;
            // 
            // checkUrgente
            // 
            this.checkUrgente.AutoSize = true;
            this.checkUrgente.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkUrgente.Location = new System.Drawing.Point(15, 111);
            this.checkUrgente.Name = "checkUrgente";
            this.checkUrgente.Size = new System.Drawing.Size(99, 25);
            this.checkUrgente.TabIndex = 5;
            this.checkUrgente.Text = "Urgente";
            this.checkUrgente.UseVisualStyleBackColor = true;
            // 
            // txtChamado
            // 
            this.txtChamado.AcceptsReturn = true;
            this.txtChamado.AcceptsTab = true;
            this.txtChamado.BackColor = System.Drawing.Color.White;
            this.txtChamado.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtChamado.Location = new System.Drawing.Point(12, 184);
            this.txtChamado.Multiline = true;
            this.txtChamado.Name = "txtChamado";
            this.txtChamado.Size = new System.Drawing.Size(409, 270);
            this.txtChamado.TabIndex = 6;
            this.txtChamado.Text = "descreva seu problema aqui...";
            this.txtChamado.Click += new System.EventHandler(this.txtChamado_Click);
            this.txtChamado.Leave += new System.EventHandler(this.txtChamado_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Descrição do Problema";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(655, 442);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(92, 44);
            this.btnEnviar.TabIndex = 8;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // NovoChamadoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(800, 543);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtChamado);
            this.Controls.Add(this.checkUrgente);
            this.Controls.Add(this.checkImportante);
            this.Controls.Add(this.checkBasico);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "NovoChamadoForm";
            this.Text = "NovoChamadoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBasico;
        private System.Windows.Forms.CheckBox checkImportante;
        private System.Windows.Forms.CheckBox checkUrgente;
        private System.Windows.Forms.TextBox txtChamado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnviar;
    }
}