using DataLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Utilizador
    {
        public string Username { get; set; }
        
        public string primeiroNome { get; set; }

        public string segundoNome { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public string contacto { get; set; }
        public string morada { get; set; } 

        public ICollection<Classificacao> classificacao { get; set; }

        public ICollection<Leilao>? leiloes {  get; set; }

        public ICollection<Carregamento>? carregamentos { get; set; }

        public double valor { get; set; }

        public double saldo_fantasma { get; set; }
    }
}
