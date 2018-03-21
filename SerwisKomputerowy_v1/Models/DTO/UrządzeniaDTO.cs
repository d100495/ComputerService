using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerwisKomputerowy_v1.Models.DTO
{
    public class UrządzeniaDTO
    {
        public int idUrządzenia { get; set; }
        public string Rodzaj_urzązenia { get; set; }
        public string Model_urządzenia { get; set; }
        public string Parametry_urządzenia { get; set; }
        public Nullable<int> idKlienta_fk { get; set; }
    }
}