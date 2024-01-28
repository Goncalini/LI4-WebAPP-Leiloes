using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Classificacao
    {
        [Key] public int avaliacaoId { get; set; }

        public string usernameCliente { get; set; }

        public string usernameUser { get; set; }
        [ForeignKey("usernameUser")]
        public Utilizador user {  get; set; }

        public int aval { get; set; }

        public string comentario { get; set; }
    }
}
