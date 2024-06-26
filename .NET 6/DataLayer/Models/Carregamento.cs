﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Carregamento
    {
        [Key] public int IDCarregamento { get; set; }
        public string Username { get; set; }
        [ForeignKey("Username")]
        public Utilizador utilizador { get; set; }

        public DateTime Data { get; set; }

        public double valor { get; set; }

    }
}
