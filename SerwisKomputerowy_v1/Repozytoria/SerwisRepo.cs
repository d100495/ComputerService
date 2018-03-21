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
    public class SerwisRepo : ISerwisRepo
    {

        private static SerwisRepo repo = null;
        private int liczbaInstancji = 0;


        public static SerwisRepo repoInstance
        {
            get
            {
                if (repo == null)
                {
                    repo = new SerwisRepo();
                }
                return repo;
            }
        }

        private SerwisRepo()
        {
            liczbaInstancji = 1; //debugging
        }



        private SerwisKomputerowyEntities db = new SerwisKomputerowyEntities();


        //======================
        //===============KLIENCI
        //======================


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

       

        public IEnumerable<Klienci> GetKlientByNazwisko(string nazwisko)
        {
            var klienci = db.Klienci.Where(x => x.Nazwisko == nazwisko);
            return klienci;
        }


        public async Task<Klienci> DeleteKlient(int id)
        {
            var result = db.Klienci.Remove(await db.Klienci.FirstOrDefaultAsync(x => x.idKlienta == id));
            return result;
        }


        public Klienci PostKlient(Klienci klient)
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



        //// PUT: api/Kliencis/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutKlienci(int id, Klienci klienci)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != klienci.idKlienta)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(klienci).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!KlienciExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //=========================
        //===============URZĄDZENIA
        //=========================


        public async Task<Urządzenia> DeleteUrzadzenie(int id)
        {

            var result = db.Urządzenia.Remove(await db.Urządzenia.FirstOrDefaultAsync(x => x.idUrządzenia == id));

            return result;
        }

        public async Task<Urządzenia> DeleteUrzadzenieByFK(int fk)
        {

            var result = db.Urządzenia.Remove(await db.Urządzenia.FirstOrDefaultAsync(x => x.idKlienta_fk == fk));
            return result;
        }

        //public async Task<Urządzenia> DeleteUrzadzenie(Urządzenia urz)
        //{
        //    var result = db.Urządzenia.Remove(await db.Urządzenia.FirstOrDefaultAsync(x=>x.Equals(x)));
        //    return result;
        //}

        public IEnumerable<UrządzeniaDTO> GetAllUrzadzenia()
        {
            var urzadzenia = db.Urządzenia.Select(urzadzenie => new UrządzeniaDTO()
            {
                idUrządzenia = urzadzenie.idUrządzenia,
                 Rodzaj_urzązenia=urzadzenie.Rodzaj_urzązenia,
                 Model_urządzenia=urzadzenie.Model_urządzenia,
                 Parametry_urządzenia=urzadzenie.Parametry_urządzenia,
                 idKlienta_fk = urzadzenie.idKlienta_fk
                 
             });
            return urzadzenia;
        }

        public IEnumerable<UrządzeniaDTO> GetUrzadzeniaKlienta(int klientId)
        {
            var urzadzenia= db.Urządzenia.Where(x=>x.idKlienta_fk==klientId).Select(urzadzenie => new UrządzeniaDTO()
            {
                idUrządzenia = urzadzenie.idUrządzenia,
                Rodzaj_urzązenia = urzadzenie.Rodzaj_urzązenia,
                Model_urządzenia = urzadzenie.Model_urządzenia,
                Parametry_urządzenia = urzadzenie.Parametry_urządzenia,
                idKlienta_fk = urzadzenie.idKlienta_fk
            });
            return urzadzenia;

        }

       
        public async Task<Urządzenia> GetUrzadzenieById(int id)
        {
            var result = await db.Urządzenia.FirstOrDefaultAsync(x => x.idUrządzenia == id);
            return result;
        }




        public Urządzenia PostUrzadzenie(Urządzenia urzadzenie)
        {
            var result = db.Urządzenia.Add(urzadzenie);
            return result;
        }

        public EntityState PutUrzadzenie(Urządzenia klient)
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


        //=========================
        //===============Usterki
        //=========================




            
        public async Task<Usterki> DeleteUsterka(int id)
        {

            var result = db.Usterki.Remove(await db.Usterki.FirstOrDefaultAsync(x => x.idUsterki == id));

            return result;
        }


        //public async Task<Usterki> DeleteUsterka(Usterki urz)
        //{

        //    var result = db.Usterki.Remove(await db.Usterki.FirstOrDefaultAsync(x=>x.Equals(x)));
        //    return result;
        //}

        public IEnumerable<UsterkiDTO> GetAllUsterki()
        {
            var usterki = db.Usterki.Select(usterka => new UsterkiDTO()
            {
                idUsterki = usterka.idUsterki,
                Opis_usterki=usterka.Opis_usterki,
                idUrządzenia_fk=usterka.idUrządzenia_fk,
                Rodzaj_usterki=usterka.Rodzaj_usterki,
                Wykonane_prace=usterka.Wykonane_prace,
                idZlecenia_fk=usterka.idZlecenia_fk,
                
             });
            return usterki;
        }

        public IEnumerable<UsterkiDTO> GetUsterkiUrzadzenia(int idurzadzenia)
        {
            var usterki= db.Usterki.Where(x=>x.idUrządzenia_fk==idurzadzenia).Select(usterka => new UsterkiDTO()
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


        //=========================
        //===============Zlecenia_dla_klienta
        //=========================




        public async Task<Zlecenia_dla_klienta> DeleteZlecenie(int id)
        {

            var result = db.Zlecenia_dla_klienta.Remove(await db.Zlecenia_dla_klienta.FirstOrDefaultAsync(x => x.idZlecenia == id));

            return result;
        }


        //public async Task<Zlecenia_dla_klienta> DeleteZlecenie(Usterki urz)
        //{

        //    var result = db.Zlecenia_dla_klienta.Remove(await db.Zlecenia_dla_klienta.FirstOrDefaultAsync(x => x.Equals(x)));
        //    return result;
        //}

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

        public IEnumerable<Zlecenia_dla_klientaDTO> GetZleceniaKlienta(int klientId)
        {
            var zlecenia = db.Zlecenia_dla_klienta.Where(x => x.idKlienta_fk == klientId).Select(zlec => new Zlecenia_dla_klientaDTO()
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
            var result = await db.Zlecenia_dla_klienta.FirstOrDefaultAsync(x => x.idZlecenia== id);
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

                    // Update oryginalych wartosci z bazy
                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }

            } while (saveFailed);
        }



        //public async Task Save()
        //{

        //    await db.SaveChangesAsync();
        //}










    }

}
