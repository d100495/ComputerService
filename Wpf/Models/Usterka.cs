using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Modele
{
    public class Usterka
    {
        public Usterka(int idUsterki, string rodzaj_usterki, string opis_usterki, string wykonane_prace, int? idZlecenia_fk, int? idUrządzenia_fk)
        {
            this.idUsterki = idUsterki;
            Rodzaj_usterki = rodzaj_usterki;
            Opis_usterki = opis_usterki;
            Wykonane_prace = wykonane_prace;
            this.idZlecenia_fk = idZlecenia_fk;
            this.idUrządzenia_fk = idUrządzenia_fk;
        }

        public Usterka(string rodzaj_usterki, string opis_usterki, string wykonane_prace, int? idZlecenia_fk, int? idUrządzenia_fk)
        {
            Rodzaj_usterki = rodzaj_usterki;
            Opis_usterki = opis_usterki;
            Wykonane_prace = wykonane_prace;
            this.idZlecenia_fk = idZlecenia_fk;
            this.idUrządzenia_fk = idUrządzenia_fk;
        }

        public Usterka() { }

        public int idUsterki { get; set; }
        public string Rodzaj_usterki { get; set; }
        public string Opis_usterki { get; set; }
        public string Wykonane_prace { get; set; }
        public Nullable<int> idZlecenia_fk { get; set; }
        public Nullable<int> idUrządzenia_fk { get; set; }


    }
}
