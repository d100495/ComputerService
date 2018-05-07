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
    public class UrzadzeniaController : ApiController
    {

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await RepositoryService.repoInstance.Deletedevice(id);
            await RepositoryService.repoInstance.Save();

            return Ok(id);
        }


        [HttpDelete]
        public async Task<IHttpActionResult> DeletedeviceByFK(int fk)
        {
            await RepositoryService.repoInstance.DeletedeviceByFK(fk);
            await RepositoryService.repoInstance.Save();

            return Ok(fk);
        }

        [HttpGet]
        public IEnumerable<UrządzeniaDTO> GetAll()
        {
            return RepositoryService.repoInstance.GetAllUrzadzenia();
        }


        [HttpGet]
        public IEnumerable<UrządzeniaDTO> GetUrzadzeniaKlienta(int clientId)
        {
            return RepositoryService.repoInstance.GetUrzadzeniaKlienta(clientId);

        }

        [HttpGet]
        public async Task<Urządzenia> Get(int id)
        {
            return await RepositoryService.repoInstance.GetdeviceById(id);
        }


        [HttpPost]
        public async Task<IHttpActionResult> Post(Urządzenia device)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            else
            {
                RepositoryService.repoInstance.PostDevice(device);
                await RepositoryService.repoInstance.Save();
                return Ok(device);
            }

        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(Urządzenia device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RepositoryService.repoInstance.Putdevice(device);
                try
                {
                    await RepositoryService.repoInstance.Save();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }

                return Ok(device);
            }


        }


    }
}