using DataLayer.Models;

namespace BlazorApp1.Models
{
    public class Utilizador
    {
        public string username { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string contacto { get; set; }
        public string morada { get; set; } 

        public Classificacao classificacao { get; set; }

        public List<Leilao>? leiloes {  get; set; }

        public Saldo saldo { get; set; }
    }
}
