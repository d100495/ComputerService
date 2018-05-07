using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SerwisKomputerowy_v1.Models;
using SerwisKomputerowy_v1.Models.DTO;
using SerwisKomputerowy_v1.Repozytoria;

namespace SerwisKomputerowy_v1.Controllers
{
    public class Zlecenia_dla_klientaController : ApiController
    {


        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            await RepositoryService.repoInstance.DeleteOrder(id);
            await RepositoryService.repoInstance.Save();
            return Ok(id);
        }


        [HttpGet]
        public IEnumerable<Zlecenia_dla_klientaDTO> GetAll()
        {
            return RepositoryService.repoInstance.GetAllOrders();
        }


        [HttpGet]
        public IEnumerable<Zlecenia_dla_klientaDTO> GetClientOrders(int clientId)
        {
            return RepositoryService.repoInstance.GetClientOrders(clientId);

        }


        [HttpGet]
        public async Task<Zlecenia_dla_klienta> Get(int id)
        {
            return await RepositoryService.repoInstance.GetOrderById(id);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(Zlecenia_dla_klienta order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RepositoryService.repoInstance.PostOrder(order);
                await RepositoryService.repoInstance.Save();
                return Ok(order);
            }

        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(Zlecenia_dla_klienta order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RepositoryService.repoInstance.PutOrder(order);
                try
                {
                    await RepositoryService.repoInstance.Save();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }

                return Ok(order);
            }


        }

    }
}