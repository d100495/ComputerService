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
            await SerwisRepo.repoInstance.DeleteUrzadzenie(id);
            await SerwisRepo.repoInstance.Save();

            return Ok(id);
        }


        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUrzadzenieByFK(int fk)
        {
            await SerwisRepo.repoInstance.DeleteUrzadzenieByFK(fk);
            await SerwisRepo.repoInstance.Save();

            return Ok(fk);
        }


        //[HttpDelete]
        //public async Task<IHttpActionResult> DeleteUrzadzenie(Urządzenia urz)
        //{

        //    await SerwisRepo.repoInstance.DeleteUrzadzenie(urz);
        //    await SerwisRepo.repoInstance.Save();
        //    return Ok(urz);
        //}


        [HttpGet]
        public IEnumerable<UrządzeniaDTO> GetAll()
        {
            return SerwisRepo.repoInstance.GetAllUrzadzenia();
        }


        [HttpGet]
        public IEnumerable<UrządzeniaDTO> GetUrzadzeniaKlienta(int klientId)
        {
            return SerwisRepo.repoInstance.GetUrzadzeniaKlienta(klientId);

        }

        [HttpGet]
        public async Task<Urządzenia> Get(int id)
        {
            return await SerwisRepo.repoInstance.GetUrzadzenieById(id);
        }


        [HttpPost]
        public async Task<IHttpActionResult> Post(Urządzenia urzadzenie)
        {
            if (!ModelState.IsValid)
            {
             
                return BadRequest(ModelState);
            }
            else
            {
                SerwisRepo.repoInstance.PostUrzadzenie(urzadzenie);
                await SerwisRepo.repoInstance.Save();
                return Ok(urzadzenie);
            }
         
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(Urządzenia urzadzenie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                SerwisRepo.repoInstance.PutUrzadzenie(urzadzenie);
                try
                {
                    await SerwisRepo.repoInstance.Save();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }

                return Ok(urzadzenie);
            }


        }


    }
}