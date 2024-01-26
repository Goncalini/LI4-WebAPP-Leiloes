using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Classificacao
    {
        public int avaliacaoId { get; set; }

        public int usernameCliente { get; set; }

        public int usernameUser { get; set; }

        public int aval { get; set; }

        public string comentario { get; set; }
    }
}
