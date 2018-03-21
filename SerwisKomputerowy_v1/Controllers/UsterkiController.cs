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

            await SerwisRepo.repoInstance.DeleteUsterka(id);
            await SerwisRepo.repoInstance.Save();
            return Ok(id);
        }


        //[HttpDelete]
        //public async Task<IHttpActionResult> DeleteUsterka(Usterki ust)
        //{

        //    await SerwisRepo.repoInstance.DeleteUsterka(ust);
        //    await SerwisRepo.repoInstance.Save();
        //    return Ok(ust);
        //}


        [HttpGet]
        public IEnumerable<UsterkiDTO> GetAll()
        {
            return SerwisRepo.repoInstance.GetAllUsterki();
        }


        [HttpGet]
        public IEnumerable<UsterkiDTO> GeUsterkiUrzadzenia(int urzadzenieId)
        {
            return SerwisRepo.repoInstance.GetUsterkiUrzadzenia(urzadzenieId);
        }


        [HttpGet]
        public IEnumerable<UsterkiDTO> GetUsterkiZlecenia(int zlecenieId)
        {
            return SerwisRepo.repoInstance.GetUsterkiZlecenia(zlecenieId);
        }


        [HttpGet]
        public async Task<Usterki> Get(int id)
        {
            return await SerwisRepo.repoInstance.GetUsterkaById(id);
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
                SerwisRepo.repoInstance.PostUsterka(usterka);
                await SerwisRepo.repoInstance.Save();
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
                SerwisRepo.repoInstance.PutUsterka(usterka);
                try
                {
                    await SerwisRepo.repoInstance.Save();
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