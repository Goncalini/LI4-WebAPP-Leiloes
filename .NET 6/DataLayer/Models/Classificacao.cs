using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Classificacao
    {
        public List<int>? classificacoes { get; set; }

        public int quantidade { get; set; }

        public double media { get; set; }

        public string comentario { get; set; }
    }
}
