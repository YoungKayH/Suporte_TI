using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Suporte_TI.Models;

namespace Suporte_TI.Forms
{
    public partial class deletarUsu : Form
    {
        public deletarUsu()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
        "Digite o ID do usuário que deseja excluir:",
        "Excluir Usuário",
        ""
    );

            if (int.TryParse(input, out int id))
            {
                var userRepo = new Usuario_Metodos();

                try
                {
                    userRepo.ExclusaoUsuario(id);
                    MessageBox.Show("Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCarregar_Click(null, null); // Recarrega a lista após a exclusão
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ID inválido. Por favor, insira um número inteiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                listView1.Items.Clear();

                var userService = new Usuario_Metodos();

                var users = userService.ReadAll();

                foreach (var user in users)
                {
                    var listItem = new ListViewItem(user.nome);
                    listItem.SubItems.Add(user.email);
                    listItem.SubItems.Add(user.sexo);
                    listItem.SubItems.Add(user.cpf);
                    listItem.SubItems.Add(user.endereco);
                    listItem.SubItems.Add(user.Id.ToString());
                    listView1.Items.Add(listItem);
                }

                MessageBox.Show($"{users.Count} usuário(s) carregado(s).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
