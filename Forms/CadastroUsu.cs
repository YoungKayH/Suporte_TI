using Npgsql;
using Suporte_TI.Data;
using Suporte_TI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suporte_TI.Forms
{
    public partial class CadastroUsu : Form1
    {
        public CadastroUsu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Preenche o ComboBox com os tipos de usuário
            cbTipoUsuario.Items.Add("Usuário Normal");
            cbTipoUsuario.Items.Add("Administrador");
            // ... adicione outros conforme necessário

            cbTipoUsuario.SelectedIndex = 0; // Seleciona o primeiro item por padrão
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Usuario novoUsuario = new Usuario
            {
                nome = txtNome.Text.Trim(),
                email = txtEmail.Text.Trim(),
                senha = CriptografarSenha(txtSenha.Text.Trim()),
                tipoId = cbTipoUsuario.SelectedIndex + 1,
                cpf = FormatCPF(txtCPF.Text),
                telefone = txtTelefone.Text,
                endereco = txtEndereco.Text,
                dataNascimento = dtpDataNasc.Value,
                sexo = rbMasculino.Checked ? "M" : "F"
            };

            try
            {
                // Validações básicas
                if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtSenha.Text) ||
                    string.IsNullOrWhiteSpace(txtCPF.Text))
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios!");
                    return;
                }
                
                var parametros = new Dictionary<string, string>
                {
                    {"@telefone", novoUsuario.telefone},
                    {"@cpf", novoUsuario.cpf},
                    {"@endereco", novoUsuario.endereco},
                    {"@nome", novoUsuario.nome},
                    {"@email", novoUsuario.email}
                };
                foreach (var param in parametros)
                {
                    if (param.Value.Length > 50) // Ajuste conforme seus limites
                    {
                        MessageBox.Show($"{param.Key} excede tamanho máximo: {param.Value.Length} caracteres");
                        return;
                    }
                }
                // Validar idade mínima (18 anos)
                //if (DateTime.Today.Year - dataNasc.Year < 18)
                //{
                //  MessageBox.Show("O usuário deve ter pelo menos 18 anos!");
                //  return;
                //}

                // Cadastrar no banco
                string connectionString = "Host=localhost;Username=postgres;Password=2005;Database=suporte_ti";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"INSERT INTO USUARIOS (
                        USU_NOME, USU_SENHA, USU_EMAIL, USU_CPF, 
                        USU_TELEFONE, USU_ENDERECO, USU_DATANASC, 
                        USU_SEXO, USU_STATUS, TIPO_ID)
                       VALUES (
                        @nome, @senha, @email, @cpf, 
                        @telefone, @endereco, @dataNasc, 
                        @sexo, 'S', @tipoId)";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("nome", novoUsuario.nome);
                        cmd.Parameters.AddWithValue("senha", novoUsuario.senha);
                        cmd.Parameters.AddWithValue("email", novoUsuario.email);
                        cmd.Parameters.AddWithValue("cpf", novoUsuario.cpf);
                        cmd.Parameters.AddWithValue("telefone", novoUsuario.telefone);
                        cmd.Parameters.AddWithValue("endereco", novoUsuario.endereco);
                        cmd.Parameters.AddWithValue("dataNasc", novoUsuario.dataNascimento);
                        cmd.Parameters.AddWithValue("sexo", novoUsuario.sexo);
                        cmd.Parameters.AddWithValue("tipoId", novoUsuario.tipoId);

                        // TESTES

                        //Console.WriteLine($"Nome: {nome}");
                        //Console.WriteLine($"Email: {email}");
                        //Console.WriteLine($"Senha: {senha}");
                        //Console.WriteLine($"CPF: {cpf}");
                        //Console.WriteLine($"Telefone: {telefone}");
                        //Console.WriteLine($"Endereço: {endereco}");
                        //Console.WriteLine($"Data Nasc: {dataNasc}");
                        //Console.WriteLine($"Sexo: {sexo}");
                        //Console.WriteLine($"TipoId: {tipoId}");

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Usuário cadastrado com sucesso!");
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao cadastrar usuário.");
                        }
                    }
                }
            }
            catch (PostgresException ex) // Use PostgresException em vez de NpgsqlException
            {
                if (ex.SqlState == "23505") // Código para violação de unique constraint
                {
                    MessageBox.Show("E-mail ou CPF já cadastrado no sistema!");
                }
                else
                {
                    MessageBox.Show($"Erro no banco de dados ({ex.SqlState}): {ex.Message}");
                }
            }
     
        }
        //Métodos Auxiliares
        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtCPF.Clear();
            txtTelefone.Clear();
            txtEndereco.Clear();
            //dtpDataNasc.Value = DateTime.Today.AddYears(-18);
            rbMasculino.Checked = true;
            cbTipoUsuario.SelectedIndex = 0;
        }
        public string CriptografarSenha(string senha)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        private string FormatCPF(string cpf)
        {
            // Remove caracteres não numéricos
            return new string(cpf.Where(char.IsDigit).ToArray());
        }
    }
}
