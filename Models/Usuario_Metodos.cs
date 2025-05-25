using Npgsql;
using Suporte_TI.Data;
using Suporte_TI.Models;
using System;
using System.Collections.Generic;

namespace Suporte_TI.Models
{
    public class Usuario_Metodos
    {
        public bool Create(Usuario usuario)
        {
            var db = new DatabaseConnection();
            var query = @"
                INSERT INTO usuarios (usu_nome, usu_email, usu_senha, tipo_id, usu_cpf, usu_telefone, usu_endereco, usu_datanasc, usu_sexo, usu_status)
                VALUES (@nome, @email, @senha, @tipoId, @cpf, @telefone, @endereco, @dataNascimento, @sexo, @status);";

            var cmd = new NpgsqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@nome", usuario.nome);
            cmd.Parameters.AddWithValue("@email", usuario.email);
            cmd.Parameters.AddWithValue("@senha", usuario.senha);
            cmd.Parameters.AddWithValue("@tipoId", usuario.tipoId);
            cmd.Parameters.AddWithValue("@cpf", usuario.cpf);
            cmd.Parameters.AddWithValue("@telefone", usuario.telefone);
            cmd.Parameters.AddWithValue("@endereco", usuario.endereco);
            cmd.Parameters.AddWithValue("@dataNascimento", usuario.dataNascimento);
            cmd.Parameters.AddWithValue("@sexo", usuario.sexo);
            cmd.Parameters.AddWithValue("@status", usuario.status);

            cmd.ExecuteNonQuery();
            return true; 
        }

        public Usuario Autenticar(string email, string senha)
        {
            var db = new DatabaseConnection();
            var query = @"
        SELECT usu_id, usu_nome, usu_email, usu_senha, tipo_id, usu_cpf, 
               usu_telefone, usu_endereco, usu_datanasc, usu_sexo, usu_status
        FROM usuarios 
        WHERE usu_email = @email AND usu_senha = @senha";

            var cmd = new NpgsqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Usuario
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("usu_id")),
                        nome = reader.GetString(reader.GetOrdinal("usu_nome")),
                        email = reader.GetString(reader.GetOrdinal("usu_email")),
                        senha = reader.GetString(reader.GetOrdinal("usu_senha")),
                        tipoId = reader.GetInt32(reader.GetOrdinal("tipo_id")),
                        cpf = reader.GetString(reader.GetOrdinal("usu_cpf")),
                        telefone = reader.GetString(reader.GetOrdinal("usu_telefone")),
                        endereco = reader.GetString(reader.GetOrdinal("usu_endereco")),
                        dataNascimento = reader.GetDateTime(reader.GetOrdinal("usu_datanasc")),
                        sexo = reader.GetString(reader.GetOrdinal("usu_sexo")),
                        status = reader.GetString(reader.GetOrdinal("usu_status"))
                    };
                }
            }

            return null;
        }

        public List<Usuario> ReadAll()
        {
            var usuarios = new List<Usuario>();
            var db = new DatabaseConnection();
            var query = "SELECT * FROM usuarios";

            var cmd = new NpgsqlCommand(query, db.GetConnection());
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuarios.Add(new Usuario
                {
                    Id = reader.GetInt32(reader.GetOrdinal("usu_id")),
                    nome = reader.GetString(reader.GetOrdinal("usu_nome")),
                    email = reader.GetString(reader.GetOrdinal("usu_email")),
                    senha = reader.GetString(reader.GetOrdinal("usu_senha")),
                    tipoId = reader.GetInt32(reader.GetOrdinal("tipo_id")),
                    cpf = reader.GetString(reader.GetOrdinal("usu_cpf")),
                    telefone = reader.GetString(reader.GetOrdinal("usu_telefone")),
                    endereco = reader.GetString(reader.GetOrdinal("usu_endereco")),
                    dataNascimento = reader.GetDateTime(reader.GetOrdinal("usu_datanasc")),
                    sexo = reader.GetString(reader.GetOrdinal("usu_sexo")),
                    status = reader.GetString(reader.GetOrdinal("usu_status"))
                });
            }

            return usuarios;
        }

        public void Update(Usuario usuario) //Nâo Utilizado ainda
        {
            var db = new DatabaseConnection();
            var query = @"
                UPDATE usuarios SET
                    usu_nome = @nome,
                    usu_email = @email,
                    usu_senha = @senha,
                    tipo_id = @tipoId,
                    usu_cpf = @cpf,
                    usu_telefone = @telefone,
                    usu_endereco = @endereco,
                    usu_datanasc = @dataNascimento,
                    usu_sexo = @sexo,
                    usu_status = @status
                WHERE usu_id = @id;";

            var cmd = new NpgsqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@id", usuario.Id);
            cmd.Parameters.AddWithValue("@nome", usuario.nome);
            cmd.Parameters.AddWithValue("@email", usuario.email);
            cmd.Parameters.AddWithValue("@senha", usuario.senha);
            cmd.Parameters.AddWithValue("@tipoId", usuario.tipoId);
            cmd.Parameters.AddWithValue("@cpf", usuario.cpf);
            cmd.Parameters.AddWithValue("@telefone", usuario.telefone);
            cmd.Parameters.AddWithValue("@endereco", usuario.endereco);
            cmd.Parameters.AddWithValue("@dataNascimento", usuario.dataNascimento);
            cmd.Parameters.AddWithValue("@sexo", usuario.sexo);
            cmd.Parameters.AddWithValue("@status", usuario.status);

            cmd.ExecuteNonQuery();
        }
		
		public void ExclusaoUsuario(int id)
		{
            var db = new DatabaseConnection();

            try
            {
                var deleteInteracoes = new NpgsqlCommand("DELETE FROM interacoes_chamado WHERE usu_id = @id", db.GetConnection());
                deleteInteracoes.Parameters.AddWithValue("@id", id);
                deleteInteracoes.ExecuteNonQuery();

                var buscarChamados = new NpgsqlCommand("SELECT cham_id FROM chamados WHERE usu_id = @id", db.GetConnection());
                buscarChamados.Parameters.AddWithValue("@id", id);
                var reader = buscarChamados.ExecuteReader();

                List<int> chamadosIds = new List<int>();
                while (reader.Read())
                {
                    chamadosIds.Add(reader.GetInt32(0));
                }
                reader.Close();

                foreach (var chamId in chamadosIds)
                {
                    var deleteMensagens = new NpgsqlCommand("DELETE FROM mensagens WHERE cham_id = @chamId", db.GetConnection());
                    deleteMensagens.Parameters.AddWithValue("@chamId", chamId);
                    deleteMensagens.ExecuteNonQuery();
                }

                var deleteChamados = new NpgsqlCommand("DELETE FROM chamados WHERE usu_id = @id", db.GetConnection());
                deleteChamados.Parameters.AddWithValue("@id", id);
                deleteChamados.ExecuteNonQuery();

                var deleteUsuario = new NpgsqlCommand("DELETE FROM usuarios WHERE usu_id = @id", db.GetConnection());
                deleteUsuario.Parameters.AddWithValue("@id", id);
                deleteUsuario.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir usuário: " + ex.Message);
            }
        }
    }
}
