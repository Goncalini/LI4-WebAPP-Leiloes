using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Categoria
    {
        [Key] public int id { get; set; }

        public string nome { get; set; }

        public ICollection<Leilao>? leiloes { get; set; }
    }
}
