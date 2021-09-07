using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rapor.Core;
using Rapor.WebApi.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rapor.UnitTest
{
    [TestClass]
    public class RaporUnitTest
    {
        private readonly Mock<IRaporServices> _raporServicesMock = new Mock<IRaporServices>();
                
        [TestMethod]
        public async Task GetRaporlar()
        {
            var controller = new RaporController(_raporServicesMock.Object);
            var response = await controller.GetRaporlar();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task CreateDetayRapor()
        {
            var controller = new RaporController(_raporServicesMock.Object);

            var response = await controller.CreateDetayRapor();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task CreateIstatistikselRapor()
        {
            var controller = new RaporController(_raporServicesMock.Object);

            var response = await controller.CreateIstatistikselRapor();

            Assert.IsNotNull(response);
        }

    }
}
