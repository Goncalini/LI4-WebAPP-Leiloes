using BlazorApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Licitacao
    {
        public int numero {  get; set; }

        public double valor { get; set; }

        public TimeOnly tempo { get; set; } 

        public Utilizador cliente {  get; set; } 
    }
}
