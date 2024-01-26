using BlazorApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Carregamento
    {
        public string Username { get; set; }

        public Utilizador utilizador { get; set; }

        public DateTime Data { get; set; }

        public double valor { get; set; }

        public int IDCarregamento { get; set; }

    }
}
