using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suporte_TI.Models
{
    public class MensagemSupabase
    {
        public int msg_id { get; set; }
        public int cham_id { get; set; }
        public int remetente_id { get; set; }
        public string remetente_nome { get; set; }
        public string mensagem { get; set; }
        public DateTime data_envio { get; set; }
    }
}
