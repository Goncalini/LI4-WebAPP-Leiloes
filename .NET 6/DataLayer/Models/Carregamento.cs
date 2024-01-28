using BlazorApp1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Carregamento
    {
        [Key] public int id { get; set; }
        public string Username { get; set; }

        public Utilizador utilizador { get; set; }

        public DateTime Data { get; set; }

        public double valor { get; set; }

    }
}
