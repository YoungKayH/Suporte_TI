﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Suporte_TI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public int tipoId { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public DateTime dataNascimento { get; set; }
        public string sexo { get; set; }
        public string status { get; set; } = "S";

        public override string ToString()
        {
            return $"{nome} ({email})";
        }
    }

}
