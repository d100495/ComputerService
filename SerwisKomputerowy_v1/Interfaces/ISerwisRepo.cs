using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using SerwisKomputerowy_v1.Models;
using SerwisKomputerowy_v1.Models.DTO;

namespace SerwisKomputerowy_v1.Repozytoria
{
    public interface ISerwisRepo
    {
        Task<Klienci> DeleteKlient(int id);
        Task<Urządzenia> DeleteUrzadzenie(int id);
        Task<Urządzenia> DeleteUrzadzenieByFK(int fk);
        Task<Usterki> DeleteUsterka(int id);
        Task<Zlecenia_dla_klienta> DeleteZlecenie(int id);
        void Dispose();
        IEnumerable<KlientDTO> GetAllKlient();
        IEnumerable<UrządzeniaDTO> GetAllUrzadzenia();
        IEnumerable<UsterkiDTO> GetAllUsterki();
        IEnumerable<Zlecenia_dla_klientaDTO> GetAllZlecenia();
        Task<Klienci> GetKlientById(int id);
        IEnumerable<Klienci> GetKlientByNazwisko(string nazwisko);
        IEnumerable<UrządzeniaDTO> GetUrzadzeniaKlienta(int klientId);
        Task<Urządzenia> GetUrzadzenieById(int id);
        Task<Usterki> GetUsterkaById(int id);
        IEnumerable<UsterkiDTO> GetUsterkiUrzadzenia(int idurzadzenia);
        IEnumerable<UsterkiDTO> GetUsterkiZlecenia(int idzlecenia);
        IEnumerable<Zlecenia_dla_klientaDTO> GetZleceniaKlienta(int klientId);
        Task<Zlecenia_dla_klienta> GetZlecenieById(int id);
        Klienci PostKlient(Klienci klient);
        Urządzenia PostUrzadzenie(Urządzenia urzadzenie);
        Usterki PostUsterka(Usterki usterka);
        Zlecenia_dla_klienta PostZlecenie(Zlecenia_dla_klienta zlecenie);
        EntityState PutKlient(Klienci klient);
        EntityState PutUrzadzenie(Urządzenia klient);
        EntityState PutUsterka(Usterki usterka);
        EntityState PutZlecenie(Zlecenia_dla_klienta zlecenie);
        Task Save();
    }
}