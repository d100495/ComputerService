using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Modele
{
    public class Urzadzenie
    {
        public int idUrządzenia { get; set; }
        public string Rodzaj_urzązenia { get; set; }
        public string Model_urządzenia { get; set; }
        public string Parametry_urządzenia { get; set; }
        //public Nullable<int> _idKlienta_fk;
        public Nullable<int> idKlienta_fk { get; set; }
        //    get { return _idKlienta_fk; }
        //    set { if (value == null)
        //            _idKlienta_fk = -1;
        //    else
        //        {
        //            _idKlienta_fk = value;
        //        }
        //            }
        //}


        public override string ToString()
        {
            return idUrządzenia + Rodzaj_urzązenia + Model_urządzenia + Parametry_urządzenia + idKlienta_fk;
        }



        public Urzadzenie(int idUrządzenia, string rodzaj_urzązenia, string model_urządzenia, string parametry_urządzenia, int? idKlienta_fk)
        {
            this.idUrządzenia = idUrządzenia;
            this.Rodzaj_urzązenia = rodzaj_urzązenia;
            this.Model_urządzenia = model_urządzenia;
            this.Parametry_urządzenia = parametry_urządzenia;
            this.idKlienta_fk = idKlienta_fk;
        }

        public Urzadzenie(string rodzaj_urzązenia, string model_urządzenia, string parametry_urządzenia, int? idKlienta_fk)
        {
        
            this.Rodzaj_urzązenia = rodzaj_urzązenia;
            this.Model_urządzenia = model_urządzenia;
            this.Parametry_urządzenia = parametry_urządzenia;
            this.idKlienta_fk = idKlienta_fk;
        }


        public Urzadzenie() { }

    }
}
