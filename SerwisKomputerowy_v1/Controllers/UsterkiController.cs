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
        public IEnumerable<UsterkiDTO> GeUsterkiUrzadzenia(int UrzadzenieId)
        {
            return RepositoryService.repoInstance.GetFlawsForDevice(UrzadzenieId);
        }


        [HttpGet]
        public IEnumerable<UsterkiDTO> GetFlawsForOrder(int zlecenieId)
        {
            return RepositoryService.repoInstance.GetFlawsForOrder(zlecenieId);
        }


        [HttpGet]
        public async Task<Usterki> Get(int id)
        {
            return await RepositoryService.repoInstance.GetFlawById(id);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(Usterki usterka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RepositoryService.repoInstance.PostFlaw(usterka);
                await RepositoryService.repoInstance.Save();
                return Ok(usterka);
            }

        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(Usterki usterka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RepositoryService.repoInstance.PutFlaw(usterka);
                try
                {
                    await RepositoryService.repoInstance.Save();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }

                return Ok(usterka);
            }


        }

    }
}