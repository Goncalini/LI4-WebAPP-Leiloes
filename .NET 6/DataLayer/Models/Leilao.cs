using System;
using BlazorApp1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Leilao
    {
        public int id {  get; set; }

        public double preco_inicial {  get; set; }

        public TimeOnly tempo_limite { get; set; }

        public string tipo {  get; set; }

        public int maior_licit {  get; set; }

        public Utilizador vendedor {  get; set; } 

        public Produto produto { get; set; }
    }
}
