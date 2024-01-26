using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DataLayer.Models
{
    public class Foto
    {
        public int idLeilao { get; set; }

        public string fotoPath { get; set; }

        public Leilao leilao { get; set; }

    }
}
