using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolekcjaGier.Models
{
    public class Gra
    {
        public string Tytul { get; set; } = "";
        public string Platforma { get; set; } = "";
        public int RokWydania { get; set; }
        public bool WersjaPudelkowa { get; set; }
        public double Ocena { get; set; }
        public DateTime DataDodania { get; set; }
        public string Zdjecie { get; set; } = "";
    }
}

