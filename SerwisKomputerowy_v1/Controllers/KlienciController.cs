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
using SerwisKomputerowy_v1.Models.DTO;
using SerwisKomputerowy_v1.Models;
using SerwisKomputerowy_v1.Repozytoria;

namespace SerwisKomputerowy_v1.Controllers
{
    public class KlienciController : ApiController
    {


        [HttpGet]
        public IEnumerable<KlientDTO> GetAll()
        {
            return RepositoryService.repoInstance.GetAllKlient();
        }


        [HttpGet]
        public async Task<Klienci> Get(int id)
        {
            return await RepositoryService.repoInstance.GetKlientById(id);
        }


        [HttpGet]
        public IEnumerable<Klienci> GetClientBySurname(string nazwisko)
        {
            return RepositoryService.repoInstance.GetClientBySurname(nazwisko);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await RepositoryService.repoInstance.DeleteKlient(id);
            await RepositoryService.repoInstance.Save();
            return Ok(id);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(Klienci klient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RepositoryService.repoInstance.PostClient(klient);
                await RepositoryService.repoInstance.Save();
                return Ok(klient);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(Klienci klient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RepositoryService.repoInstance.PutKlient(klient);
                try
                {
                    await RepositoryService.repoInstance.Save();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }

                return Ok(klient);
            }



        }


    }
}