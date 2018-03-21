using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerwisKomputerowy_v1.Models.DTO
{
    public class UsterkiDTO
    {
        public int idUsterki { get; set; }
        public string Rodzaj_usterki { get; set; }
        public string Opis_usterki { get; set; }
        public string Wykonane_prace { get; set; }
        public Nullable<int> idZlecenia_fk { get; set; }
        public Nullable<int> idUrządzenia_fk { get; set; }
    }
}