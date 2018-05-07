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
    public class UsterkiController : ApiController
    {


        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {

            await RepositoryService.repoInstance.DeleteFlaw(id);
            await RepositoryService.repoInstance.Save();
            return Ok(id);
        }

        [HttpGet]
        public IEnumerable<UsterkiDTO> GetAll()
        {
            return RepositoryService.repoInstance.GetAllFlaws();
        }


        [HttpGet]
        public IEnumerable<UsterkiDTO> GetFlawsForDevice(int deviceId)
        {
            return RepositoryService.repoInstance.GetFlawsForDevice(deviceId);
        }


        [HttpGet]
        public IEnumerable<UsterkiDTO> GetFlawsForOrder(int orderId)
        {
            return RepositoryService.repoInstance.GetFlawsForOrder(orderId);
        }


        [HttpGet]
        public async Task<Usterki> Get(int id)
        {
            return await RepositoryService.repoInstance.GetFlawById(id);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(Usterki flaw)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RepositoryService.repoInstance.PostFlaw(flaw);
                await RepositoryService.repoInstance.Save();
                return Ok(flaw);
            }

        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(Usterki flaw)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RepositoryService.repoInstance.PutFlaw(flaw);
                try
                {
                    await RepositoryService.repoInstance.Save();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }

                return Ok(flaw);
            }


        }

    }
}