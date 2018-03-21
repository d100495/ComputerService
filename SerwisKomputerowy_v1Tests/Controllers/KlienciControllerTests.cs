using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerwisKomputerowy_v1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SerwisKomputerowy_v1;
using SerwisKomputerowy_v1.Repozytoria;
using SerwisKomputerowy_v1.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace SerwisKomputerowy_v1.Controllers.Tests
{
    [TestClass()]
    public class KlienciControllerTests
    {

        private Mock<SerwisRepo> mockRepository { get; set; }
        private KlienciController controller { get; set; }



        [TestMethod()]
        public async Task GetKlientTest()
        {
            mockRepository.Setup(x => x.GetKlientById(14)).ReturnsAsync(new Klienci { idKlienta = 14 });

            var result = await controller.Get(14);

      
            Assert.AreEqual(14, result.idKlienta);
            
        }

        [TestMethod]
        public async Task GetKlientNullTest()
        {

            var actionResult = await controller.Get(4);


            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));

        }


    }
}