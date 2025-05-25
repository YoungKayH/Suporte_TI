using Npgsql;
using Suporte_TI.Data;
using Suporte_TI.Models;
using System;
using System.Collections.Generic;

namespace Suporte_TI.Repositories
{
    public class UsuarioRepository
    {
        public void Create(Usuario usuario)
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
        }

        public List<Usuario> ReadAll()
        {
            var usuarios = new List<Usuario>();
            var db = new DatabaseConnection();
            var query = "SELECT * FROM usuarios WHERE status = 'S';";

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

        public void Update(Usuario usuario)
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
                WHERE id = @id;";

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

        public void ChangeStatus(int id)
        {
            var db = new DatabaseConnection();
            var query = "UPDATE usuarios SET status = 'N' WHERE id = @id;";

            var cmd = new NpgsqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
		
		public void ExclusaoUsuario(int id)
		{
			var db = new DatabaseConnection();
			var query = "DELETE FROM usuarios WHERE id = @id";
			
			var cmd = new NpgsqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
		}
    }
}
