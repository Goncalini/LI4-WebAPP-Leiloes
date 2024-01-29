using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Leilao
    {
        public int LeilãoID {  get; set; }

        public double preco_inicial {  get; set; }

        public string tipo { get; set; }

        public DateTime dataDeTermino { get; set; }

        public string vendedorId {  get; set; }
        [ForeignKey("vendedorId")]
        public Utilizador Vendedor { get; set; }

        public int idCategoria { get; set; }
        [ForeignKey("idCategoria")]
        public Categoria categoria_produto { get; set; }

        public string nome { get; set; }

        public string marca { get; set; }

        public string descricao { get; set; }

        public string estado { get; set; }
    }
}
