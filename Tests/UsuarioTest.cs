using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suporte_TI.Models;
//using Microsoft.VisualStudio.TestTools.UnitTesting

namespace Suporte_TI.Tests
{
    [TestFixture]
    public class UsuarioTest
    {
        [Test]
        public void DeveAutenticarUsuarioComCredenciaisValidas()
        {
            var repositorio = new Usuario_Metodos();
            string nome = "admin";
            string senha = "123ftr";

            var usuario = repositorio.Autenticar(nome, senha);

            Assert.That(usuario, Is.Not.Null);
            Assert.That(usuario.nome, Is.EqualTo(nome));
        }
        [Test]
        public void DeveCadastrarUsuarioNovo()
        {
            var repositorio = new Usuario_Metodos();
            var novoUsuario = new Usuario
            {
                nome = "Kaylan",
                email = "kaylan_teste@example.com",
                senha = "123456",
                tipoId = 1,
                cpf = "12345678901",
                telefone = "11999999999",
                endereco = "Rua Teste",
                dataNascimento = DateTime.Now.AddYears(-20),
                sexo = "M",
                status = "Ativo"
            };
        
            bool resultado = repositorio.Create(novoUsuario);

            Assert.That(resultado, Is.True, "O método Create deve retornar true para cadastro bem-sucedido.");

            // Verifica se o usuário pode ser autenticado (note que o Autenticar usa email, não nome)
            var usuarioCadastrado = repositorio.Autenticar(novoUsuario.email, novoUsuario.senha);
            Assert.That(usuarioCadastrado, Is.Not.Null, "O usuário deve ser autenticável após o cadastro.");
            Assert.That(usuarioCadastrado.nome, Is.EqualTo(novoUsuario.nome), "O nome do usuário cadastrado deve ser igual ao informado.");
            Assert.That(usuarioCadastrado.email, Is.EqualTo(novoUsuario.email), "O e-mail do usuário cadastrado deve ser igual ao informado.");

        }
    }
}
