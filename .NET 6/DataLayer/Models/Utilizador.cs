using DataLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Utilizador
    {
        public string usernameId { get; set; }
        
        public string primeiroNome { get; set; }

        public string segundoNome { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public string contacto { get; set; }
        public string morada { get; set; } 

        public Classificacao classificacao { get; set; }

        public List<Leilao>? leiloes {  get; set; }

        public Saldo saldo { get; set; }
    }
}
