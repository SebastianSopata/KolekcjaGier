using SQLite;

namespace KolekcjaGier.Models
{
    public class Gra
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Tytul { get; set; } = "";
        public string Platforma { get; set; } = "";
        public int RokWydania { get; set; }
        public bool WersjaPudelkowa { get; set; }
        public double Ocena { get; set; }
        public DateTime DataDodania { get; set; }
        public string Zdjecie { get; set; } = "";
    }
}