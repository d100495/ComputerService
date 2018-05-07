using SerwisKomputerowy_v1.Models.DTO;
using SerwisKomputerowy_v1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace SerwisKomputerowy_v1.Repozytoria
{
    public class RepositoryService : IRepositoryService
    {

        private static RepositoryService repo = null;
        private int liczbaInstancji = 0;


        public static RepositoryService repoInstance
        {
            get
            {
                if (repo == null)
                {
                    repo = new RepositoryService();
                }
                return repo;
            }
        }

        private RepositoryService()
        {
            liczbaInstancji = 1;
        }



        private SerwisKomputerowyEntities db = new SerwisKomputerowyEntities();



        public IEnumerable<KlientDTO> GetAllKlient()
        {
            var klienci = db.Klienci.Select(klient => new KlientDTO()
            {
                idKlienta = klient.idKlienta,
                Imie = klient.Imie,
                Nazwisko = klient.Nazwisko,
                Adres = klient.Adres,
                Numer_telefonu = klient.Numer_telefonu
            });
            return klienci;
        }



        public async Task<Klienci> GetKlientById(int id)
        {
            var result = await db.Klienci.FirstOrDefaultAsync(x => x.idKlienta == id);
            return result;
        }



        public IEnumerable<Klienci> GetClientBySurname(string nazwisko)
        {
            var klienci = db.Klienci.Where(x => x.Nazwisko == nazwisko);
            return klienci;
        }


        public async Task<Klienci> DeleteKlient(int id)
        {
            var result = db.Klienci.Remove(await db.Klienci.FirstOrDefaultAsync(x => x.idKlienta == id));
            return result;
        }


        public Klienci PostClient(Klienci klient)
        {
            var result = db.Klienci.Add(klient);
            return result;
        }

        public EntityState PutKlient(Klienci klient)
        {

            var local = db.Set<Klienci>()
                         .Local
                         .FirstOrDefault(f => f.idKlienta == klient.idKlienta);

            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            var result = db.Entry(klient).State = EntityState.Modified;

            return result;

        }

        public async Task<Urządzenia> Deletedevice(int id)
        {

            var result = db.Urządzenia.Remove(await db.Urządzenia.FirstOrDefaultAsync(x => x.idUrządzenia == id));

            return result;
        }

        public async Task<Urządzenia> DeletedeviceByFK(int fk)
        {

            var result = db.Urządzenia.Remove(await db.Urządzenia.FirstOrDefaultAsync(x => x.idKlienta_fk == fk));
            return result;
        }

        public IEnumerable<UrządzeniaDTO> GetAllUrzadzenia()
        {
            var urzadzenia = db.Urządzenia.Select(device => new UrządzeniaDTO()
            {
                idUrządzenia = device.idUrządzenia,
                Rodzaj_urzązenia = device.Rodzaj_urzązenia,
                Model_urządzenia = device.Model_urządzenia,
                Parametry_urządzenia = device.Parametry_urządzenia,
                idKlienta_fk = device.idKlienta_fk

            });
            return urzadzenia;
        }

        public IEnumerable<UrządzeniaDTO> GetUrzadzeniaKlienta(int clientId)
        {
            var urzadzenia = db.Urządzenia.Where(x => x.idKlienta_fk == clientId).Select(device => new UrządzeniaDTO()
            {
                idUrządzenia = device.idUrządzenia,
                Rodzaj_urzązenia = device.Rodzaj_urzązenia,
                Model_urządzenia = device.Model_urządzenia,
                Parametry_urządzenia = device.Parametry_urządzenia,
                idKlienta_fk = device.idKlienta_fk
            });
            return urzadzenia;

        }


        public async Task<Urządzenia> GetdeviceById(int id)
        {
            var result = await db.Urządzenia.FirstOrDefaultAsync(x => x.idUrządzenia == id);
            return result;
        }




        public Urządzenia PostDevice(Urządzenia device)
        {
            var result = db.Urządzenia.Add(device);
            return result;
        }

        public EntityState Putdevice(Urządzenia klient)
        {
            var local = db.Set<Urządzenia>()
                        .Local
                        .FirstOrDefault(f => f.idUrządzenia == klient.idUrządzenia);

            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            var result = db.Entry(klient).State = EntityState.Modified;

            return result;
        }






        public async Task<Usterki> DeleteFlaw(int id)
        {

            var result = db.Usterki.Remove(await db.Usterki.FirstOrDefaultAsync(x => x.idUsterki == id));

            return result;
        }


        public IEnumerable<UsterkiDTO> GetAllUsterki()
        {
            var usterki = db.Usterki.Select(usterka => new UsterkiDTO()
            {
                idUsterki = usterka.idUsterki,
                Opis_usterki = usterka.Opis_usterki,
                idUrządzenia_fk = usterka.idUrządzenia_fk,
                Rodzaj_usterki = usterka.Rodzaj_usterki,
                Wykonane_prace = usterka.Wykonane_prace,
                idZlecenia_fk = usterka.idZlecenia_fk,

            });
            return usterki;
        }

        public IEnumerable<UsterkiDTO> GetUsterkiUrzadzenia(int idurzadzenia)
        {
            var usterki = db.Usterki.Where(x => x.idUrządzenia_fk == idurzadzenia).Select(usterka => new UsterkiDTO()
            {
                idUsterki = usterka.idUsterki,
                Opis_usterki = usterka.Opis_usterki,
                idUrządzenia_fk = usterka.idUrządzenia_fk,
                Rodzaj_usterki = usterka.Rodzaj_usterki,
                Wykonane_prace = usterka.Wykonane_prace,
                idZlecenia_fk = usterka.idZlecenia_fk
            });
            return usterki;

        }

        public IEnumerable<UsterkiDTO> GetUsterkiZlecenia(int idzlecenia)
        {
            var usterki = db.Usterki.Where(x => x.idZlecenia_fk == idzlecenia).Select(usterka => new UsterkiDTO()
            {
                idUsterki = usterka.idUsterki,
                Opis_usterki = usterka.Opis_usterki,
                idUrządzenia_fk = usterka.idUrządzenia_fk,
                Rodzaj_usterki = usterka.Rodzaj_usterki,
                Wykonane_prace = usterka.Wykonane_prace,
                idZlecenia_fk = usterka.idZlecenia_fk
            });
            return usterki;

        }


        public async Task<Usterki> GetUsterkaById(int id)
        {
            var result = await db.Usterki.FirstOrDefaultAsync(x => x.idUsterki == id);
            return result;
        }




        public Usterki PostUsterka(Usterki usterka)
        {
            var result = db.Usterki.Add(usterka);
            return result;
        }

        public EntityState PutUsterka(Usterki usterka)
        {
            var local = db.Set<Usterki>()
                        .Local
                        .FirstOrDefault(f => f.idUsterki == usterka.idUsterki);

            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            var result = db.Entry(usterka).State = EntityState.Modified;

            return result;
        }





        public async Task<Zlecenia_dla_klienta> DeleteZlecenie(int id)
        {

            var result = db.Zlecenia_dla_klienta.Remove(await db.Zlecenia_dla_klienta.FirstOrDefaultAsync(x => x.idZlecenia == id));

            return result;
        }


        public IEnumerable<Zlecenia_dla_klientaDTO> GetAllZlecenia()
        {
            var zlecenia = db.Zlecenia_dla_klienta.Select(zlec => new Zlecenia_dla_klientaDTO()
            {
                idZlecenia = zlec.idZlecenia,
                Data_przyjęcia_zlecenia = zlec.Data_przyjęcia_zlecenia,
                Data_wykonania = zlec.Data_wykonania,
                Całkowity_koszt = zlec.Całkowity_koszt,
                idKlienta_fk = zlec.idKlienta_fk

            });
            return zlecenia;
        }

        public IEnumerable<Zlecenia_dla_klientaDTO> GetZleceniaKlienta(int clientId)
        {
            var zlecenia = db.Zlecenia_dla_klienta.Where(x => x.idKlienta_fk == clientId).Select(zlec => new Zlecenia_dla_klientaDTO()
            {
                idZlecenia = zlec.idZlecenia,
                Data_przyjęcia_zlecenia = zlec.Data_przyjęcia_zlecenia,
                Data_wykonania = zlec.Data_wykonania,
                Całkowity_koszt = zlec.Całkowity_koszt,
                idKlienta_fk = zlec.idKlienta_fk
            });
            return zlecenia;

        }


        public async Task<Zlecenia_dla_klienta> GetZlecenieById(int id)
        {
            var result = await db.Zlecenia_dla_klienta.FirstOrDefaultAsync(x => x.idZlecenia == id);
            return result;
        }




        public Zlecenia_dla_klienta PostZlecenie(Zlecenia_dla_klienta zlecenie)
        {
            var result = db.Zlecenia_dla_klienta.Add(zlecenie);
            return result;
        }

        public EntityState PutZlecenie(Zlecenia_dla_klienta zlecenie)
        {
            var local = db.Set<Zlecenia_dla_klienta>()
                       .Local
                       .FirstOrDefault(f => f.idZlecenia == zlecenie.idZlecenia);

            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            var result = db.Entry(zlecenie).State = EntityState.Modified;

            return result;
        }


















        public void Dispose()
        {
            db.Dispose();
        }






        public async Task Save()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }

            } while (saveFailed);
        }












    }

}
