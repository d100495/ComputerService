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


namespace SerwisKomputerowy_v1.Controllers.Tests
{
    [TestClass()]
    public class KlienciControllerTests
    {

        private Mock<RepositoryService> mockRepository { get; set; }
        private KlienciController controller { get; set; }
    }
}