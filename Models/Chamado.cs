using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suporte_TI.Models
{
    internal class Chamado
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string Status { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public int PrioridadeId { get; set; }
        public Chamado(int id, string descricao, DateTime dataAbertura, DateTime? dataFechamento, string status, int usuarioId, int categoriaId, int prioridadeId)
        {
            Id = id;
            Descricao = descricao;
            DataAbertura = dataAbertura;
            DataFechamento = dataFechamento;
            Status = status;
            UsuarioId = usuarioId;
            CategoriaId = categoriaId;
            PrioridadeId = prioridadeId;
        }
    }
}
