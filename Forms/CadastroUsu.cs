using Npgsql;
using Suporte_TI.Data;
using Suporte_TI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Suporte_TI.Forms
{
    public partial class CadastroUsu : Form
    {
        public CadastroUsu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            cbTipoUsuario.Items.Add("Usuário Normal");
            cbTipoUsuario.Items.Add("Administrador");

            cbTipoUsuario.SelectedIndex = 0;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            //Form1 Login = new Form1();
            //Login.Show();
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
                    if (param.Value.Length > 50)
                    {
                        MessageBox.Show($"{param.Key} excede tamanho máximo: {param.Value.Length} caracteres");
                        return;
                    }
                }

                // Salvar usando o repositório
                var repo = new Usuario_Metodos();
                repo.Create(novoUsuario);

                MessageBox.Show("Usuário cadastrado com sucesso!");
                LimparCampos();
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "23505")
                {
                    MessageBox.Show("E-mail ou CPF já cadastrado no sistema!");
                }
                else
                {
                    MessageBox.Show($"Erro no banco de dados ({ex.SqlState}): {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar usuário: {ex.Message}");
            }
        }
        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtCPF.Clear();
            txtTelefone.Clear();
            txtEndereco.Clear();
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
            return new string(cpf.Where(char.IsDigit).ToArray());
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text.Contains(" "))
            {
                MessageBox.Show("Não são permitidos espaços neste campo!");
                txtNome.Text = txtNome.Text.Replace(" ", "");
            }
        }

        private void dtpDataNasc_Validating(object sender, CancelEventArgs e)
        {
            if (!DateTime.TryParseExact(
                dtpDataNasc.Text,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime dataNascimento))
            {
                MessageBox.Show("Data inválida! Use o formato DD/MM/AAAA.");
                e.Cancel = true;
            }
            else if (dataNascimento > DateTime.Today)
            {
                MessageBox.Show("Data de nascimento não pode ser futura!");
                e.Cancel = true;
            }
            else if (dataNascimento.Year < 1900)
            {
                MessageBox.Show("Data de nascimento muito antiga!");
                e.Cancel = true;
            }
        }

        private void txtEndereco_Validating(object sender, CancelEventArgs e)
        {
            string endereco = txtEndereco.Text.Trim();

            if (string.IsNullOrEmpty(endereco) || !endereco.Any(char.IsLetter))
            {
                MessageBox.Show("Endereço inválido! Deve conter pelo menos uma letra.");
                e.Cancel = true;
            }
        }
    }
}
