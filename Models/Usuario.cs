using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Suporte_TI.Models
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Nivel { get; set; }
    }

}
