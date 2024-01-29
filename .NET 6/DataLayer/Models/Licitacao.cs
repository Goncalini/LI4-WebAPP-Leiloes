using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Licitacao
    {
        [Key]public int LicitaçãoID {  get; set; }

        public string userUsername { get; set; }

        public int iDLeilao { get; set; }

        public double valor { get; set; }

        public DateTime tempo { get; set; }
        [ForeignKey("userUsername")]
        public Utilizador cliente {  get; set; }
        [ForeignKey("iDLeilao")]
        public Leilao leilao { get; set; }
    }
}
