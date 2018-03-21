using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerwisKomputerowy_v1.Models.DTO
{
    public class Zlecenia_dla_klientaDTO
    {
        public int idZlecenia { get; set; }
        public Nullable<System.DateTime> Data_przyjęcia_zlecenia { get; set; }
        public Nullable<System.DateTime> Data_wykonania { get; set; }
        public Nullable<decimal> Całkowity_koszt { get; set; }
        public Nullable<int> idKlienta_fk { get; set; }

    }
}