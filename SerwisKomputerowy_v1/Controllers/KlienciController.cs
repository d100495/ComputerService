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
            return SerwisRepo.repoInstance.GetAllKlient();
        }


        [HttpGet]
        public async Task<Klienci> Get(int id)
        {
            return await SerwisRepo.repoInstance.GetKlientById(id);
        }


        [HttpGet]
        public IEnumerable<Klienci> GetKlientByNazwisko(string nazwisko)
        {
            return SerwisRepo.repoInstance.GetKlientByNazwisko(nazwisko);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await SerwisRepo.repoInstance.DeleteKlient(id);
            await SerwisRepo.repoInstance.Save();
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
                SerwisRepo.repoInstance.PostKlient(klient);
                await SerwisRepo.repoInstance.Save();
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
                SerwisRepo.repoInstance.PutKlient(klient);
                try
                {
                    await SerwisRepo.repoInstance.Save();
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