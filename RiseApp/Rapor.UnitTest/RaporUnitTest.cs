using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rapor.Core;
using Rapor.WebApi.Controllers;
using System.Threading.Tasks;

namespace Rapor.UnitTest
{
    [TestClass]
    public class RaporUnitTest
    {
        private readonly IRaporServices _raporServices;

        public RaporUnitTest(IRaporServices raporServices)
        {
            _raporServices = raporServices;
        }

        [TestMethod]
        public async Task GetRaporlarAsync()
        {
            var controller = new RaporController(_raporServices);

            var response = await controller.GetRaporlar();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task CreateDetayRapor()
        {
            var controller = new RaporController(_raporServices);

            var response = await controller.CreateDetayRapor();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task CreateIstatistikselRapor()
        {
            var controller = new RaporController(_raporServices);

            var response = await controller.CreateIstatistikselRapor();

            Assert.IsNotNull(response);
        }

    }
}
