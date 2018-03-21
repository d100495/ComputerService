using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerwisKomputerowy_v1.Models.DTO
{
    public class KlientDTO
    {
        public int idKlienta { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public string Adres { get; set; }
        public Nullable<int> Numer_telefonu { get; set; }
    }
}