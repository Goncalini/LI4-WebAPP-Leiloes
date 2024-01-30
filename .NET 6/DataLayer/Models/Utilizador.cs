using DataLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Utilizador
    {
        public string Username { get; set; }
        
        public string nome { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public string contacto { get; set; }
        public string morada { get; set; } 
        public double valor { get; set; }

        public double saldo_fantasma { get; set; }
    }
}
