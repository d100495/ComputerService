using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Modele
{
    public class Zlecenie_dla_klienta
    {

        public int idZlecenia { get; set; }
        public Nullable<System.DateTime> Data_przyjęcia_zlecenia { get; set; }
        public Nullable<System.DateTime> Data_wykonania { get; set; }
        public Nullable<decimal> Całkowity_koszt { get; set; }
        public Nullable<int> idKlienta_fk { get; set; }


        public Zlecenie_dla_klienta(int idZlecenia, DateTime? data_przyjęcia_zlecenia, DateTime? data_wykonania, decimal? całkowity_koszt, int? idKlienta_fk)
        {
            this.idZlecenia = idZlecenia;
            this.Data_przyjęcia_zlecenia = data_przyjęcia_zlecenia;
            this.Data_wykonania = data_wykonania;
            this.Całkowity_koszt = całkowity_koszt;
            this.idKlienta_fk = idKlienta_fk;
        }


        public Zlecenie_dla_klienta(DateTime? data_przyjęcia_zlecenia, DateTime? data_wykonania, decimal? całkowity_koszt, int? idKlienta_fk)
        {
            this.Data_przyjęcia_zlecenia = data_przyjęcia_zlecenia;
            this.Data_wykonania = data_wykonania;
            this.Całkowity_koszt = całkowity_koszt;
            this.idKlienta_fk = idKlienta_fk;
        }


        public Zlecenie_dla_klienta() { }

    }
}
