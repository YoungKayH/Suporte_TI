﻿using System;

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
            this.label1 = new System.Windows.Forms.Label();
            this.txtChamado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.cbPrioridade = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(280, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prioridade do Problema";
            // 
            // txtChamado
            // 
            this.txtChamado.AcceptsReturn = true;
            this.txtChamado.AcceptsTab = true;
            this.txtChamado.BackColor = System.Drawing.Color.White;
            this.txtChamado.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtChamado.Location = new System.Drawing.Point(193, 140);
            this.txtChamado.Multiline = true;
            this.txtChamado.Name = "txtChamado";
            this.txtChamado.Size = new System.Drawing.Size(409, 270);
            this.txtChamado.TabIndex = 6;
            this.txtChamado.Text = "descreva um breve resumo aqui...";
            this.txtChamado.Click += new System.EventHandler(this.txtChamado_Click);
            this.txtChamado.Leave += new System.EventHandler(this.txtChamado_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(280, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Descrição do Problema";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(341, 416);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(92, 44);
            this.btnEnviar.TabIndex = 8;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // cbPrioridade
            // 
            this.cbPrioridade.FormattingEnabled = true;
            this.cbPrioridade.Location = new System.Drawing.Point(193, 52);
            this.cbPrioridade.Name = "cbPrioridade";
            this.cbPrioridade.Size = new System.Drawing.Size(406, 24);
            this.cbPrioridade.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "13/05/2025 21:49:49";
            // 
            // NovoChamadoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(800, 543);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbPrioridade);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtChamado);
            this.Controls.Add(this.label1);
            this.Name = "NovoChamadoForm";
            this.Text = "NovoChamadoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChamado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.ComboBox cbPrioridade;
        private System.Windows.Forms.Label label3;
    }
}