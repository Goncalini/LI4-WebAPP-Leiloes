using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Produto
    {
        public int idCategoria {  get; set; }
        public Categoria categoria_produto { get; set; }
        
        public string nome { get; set; }

        public string marca { get; set;}

        public string descricao { get; set;}

        public string estado { get; set;}
    }
}
