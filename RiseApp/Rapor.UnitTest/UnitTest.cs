using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rapor.Core;
using Rapor.WebApi.Controllers;
using System.Collections.Generic;

namespace Rapor.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        private readonly IRaporServices _raporServices;

        [TestMethod]
        public void GetRaporlar()
        {
            var controller = new RaporController(_raporServices);

            var response = controller.GetRaporlar();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void CreateDetayRapor()
        {
            var controller = new RaporController(_raporServices);

            var response = controller.CreateDetayRapor();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void CreateIstatistikselRapor()
        {
            var controller = new RaporController(_raporServices);

            var response = controller.CreateIstatistikselRapor();

            Assert.IsNotNull(response);
        }

    }
}
