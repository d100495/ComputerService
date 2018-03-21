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

            await SerwisRepo.repoInstance.DeleteZlecenie(id);
            await SerwisRepo.repoInstance.Save();
            return Ok(id);
        }




        [HttpGet]
        public IEnumerable<Zlecenia_dla_klientaDTO> GetAll()
        {
            return SerwisRepo.repoInstance.GetAllZlecenia();
        }


        [HttpGet]
        public IEnumerable<Zlecenia_dla_klientaDTO> GetZleceniaKlienta(int klientId)
        {
            return SerwisRepo.repoInstance.GetZleceniaKlienta(klientId);

        }


        [HttpGet]
        public async Task<Zlecenia_dla_klienta> Get(int id)
        {
            return await SerwisRepo.repoInstance.GetZlecenieById(id);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(Zlecenia_dla_klienta zlecenie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                SerwisRepo.repoInstance.PostZlecenie(zlecenie);
                await SerwisRepo.repoInstance.Save();
                return Ok(zlecenie);
            }
          
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(Zlecenia_dla_klienta zlecenie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                SerwisRepo.repoInstance.PutZlecenie(zlecenie);
                try
                {
                    await SerwisRepo.repoInstance.Save();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw ex;
                }

                return Ok(zlecenie);
            }


        }

    }
}