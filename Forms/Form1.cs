using Suporte_TI.Data;
using Npgsql;
using Suporte_TI.Forms;
using Suporte_TI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suporte_TI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nomeDigitado = txtLogin.Text.Trim();
            string senhaDigitada = txtSenha.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomeDigitado) || string.IsNullOrWhiteSpace(senhaDigitada))
            {
                MessageBox.Show("Por favor insira os dados de login!",
                                "Campos sem dados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            CadastroUsu desc = new CadastroUsu();
            string senhaHash = desc.CriptografarSenha(txtSenha.Text);

            try
            {
                using (DatabaseConnection dbConnection = new DatabaseConnection())
                {
                    var conexao = dbConnection.GetConnection();
                    Console.WriteLine("Conexão estabelecida com sucesso!");

                    string sql = "SELECT usu_id, usu_nome, usu_senha, tipo_id FROM usuarios WHERE usu_nome = @nome AND usu_senha = @senha";

                    using (var cmd = new NpgsqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("nome", nomeDigitado);
                        cmd.Parameters.AddWithValue("senha", senhaHash);


                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("usu_id"));
                                string nome = reader.GetString(reader.GetOrdinal("usu_nome"));
                                int tipoId = reader.GetInt32(reader.GetOrdinal("tipo_id"));

                                SessaoUsuario.UsuarioLogado = new Usuario
                                {
                                    Id = id,
                                    nome = nome,
                                    tipoId = tipoId
                                };

                                // Login bem-sucedido
                                Menu menu = new Menu();
                                menu.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Usuario ou senha incorretos!",
                                                "Erro de Login",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar no banco: {ex.Message}",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            CadastroUsu cad = new CadastroUsu();
            cad.Show();
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}

