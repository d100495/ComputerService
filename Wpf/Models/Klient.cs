using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf
{
    public class Klient
    {
        public int idKlienta { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string Adres { get; set; }
        public Nullable<int> Numer_telefonu { get; set; }


        public override string ToString()
        {
            return "ID: " + idKlienta + "  Nazwisko: " + Nazwisko + "  Imie: " + Imie + "  Adres: "+Adres+ "  Numer tel: " + Numer_telefonu;
        }


        public Klient(string nazwisko, string Imie, string adres, int? numertel)
        {
            this.Nazwisko = nazwisko;
            this.Imie = Imie;
            this.Adres = adres;
            this.Numer_telefonu = numertel;
        }

        public Klient(int id,string nazwisko, string Imie, string adres, int? numertel)
        {
            this.idKlienta = id;
            this.Nazwisko = nazwisko;
            this.Imie = Imie;
            this.Adres = adres;
            this.Numer_telefonu = numertel;
        }


        public Klient() { }

    }
}
