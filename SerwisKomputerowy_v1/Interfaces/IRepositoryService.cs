using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using SerwisKomputerowy_v1.Models;
using SerwisKomputerowy_v1.Models.DTO;

namespace SerwisKomputerowy_v1.Repozytoria
{
    public interface IRepositoryService
    {
        Task<Klienci> DeleteClient(int id);
        Task<Urządzenia> DeleteDevice(int id);
        Task<Urządzenia> DeleteDeviceByFK(int fk);
        Task<Usterki> DeleteFlaw(int id);
        Task<Zlecenia_dla_klienta> DeleteOrder(int id);
        void Dispose();
        IEnumerable<KlientDTO> GetAllClients();
        IEnumerable<UrządzeniaDTO> GetAllDevices();
        IEnumerable<UsterkiDTO> GetAllFlaws();
        IEnumerable<Zlecenia_dla_klientaDTO> GetAllOrders();
        Task<Klienci> GetClientById(int id);
        IEnumerable<Klienci> GetClientBySurname(string surname);
        IEnumerable<UrządzeniaDTO> GetClientDevices(int clientId);
        Task<Urządzenia> GetDeviceById(int id);
        Task<Usterki> GetFlawById(int id);
        IEnumerable<UsterkiDTO> GetFlawsForDevice(int deviceId);
        IEnumerable<UsterkiDTO> GetFlawsForOrder(int orderId);
        IEnumerable<Zlecenia_dla_klientaDTO> GetClientOrders(int clientId);
        Task<Zlecenia_dla_klienta> GetOrderById(int id);
        Klienci PostClient(Klienci klient);
        Urządzenia PostDevice(Urządzenia device);
        Usterki PostFlaw(Usterki flaw);
        Zlecenia_dla_klienta PostOrder(Zlecenia_dla_klienta order);
        EntityState PutClient(Klienci client);
        EntityState PutDevice(Urządzenia client);
        EntityState PutFlaw(Usterki flaw);
        EntityState PutOrder(Zlecenia_dla_klienta zlecenie);
        Task Save();
    }
}