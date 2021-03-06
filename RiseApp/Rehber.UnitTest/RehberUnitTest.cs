using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rehber.Core;
using Rehber.Core.Models;
using Rehber.WebApi.Controllers;
using System;


namespace Rehber.UnitTest
{
    [TestClass]
    public class RehberUnitTest
    {
        private readonly Mock<IRehberServices> _rehberServicesMock = new Mock<IRehberServices>();

        [TestMethod]
        public void KisiEkle()
        {                    
            var controller = new RehberController(_rehberServicesMock.Object);

            KisiModel request = new KisiModel()
            {
                Ad = "Ta?k?n",
                Soyad = "Binbir",
                Firma = "Binbir Company"
            };

            var response = controller.KisiEkle(request);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void KisiSil()
        {
            var controller = new RehberController(_rehberServicesMock.Object);
            Guid guid = new Guid();
            var response = controller.KisiSil(guid);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void KisiGetir()
        {
            var controller = new RehberController(_rehberServicesMock.Object);
            Guid guid = new Guid();
            var response = controller.KisiGetir(guid);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void AddIletisimBilgisi()
        {
            var controller = new RehberController(_rehberServicesMock.Object);
            Guid guid = new Guid();           
            KisiModel request = new KisiModel()
            {
                UUID = guid,
                IletisimBilgisi =
                {
                    TelefonNumarasi = "155",
                    EMailAdresi = "taskin@gmail.com",
                    Konum = "Istanbul"
                }
            };

            var response = controller.AddIletisimBilgisi(request);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void DeleteIletisimBilgisi()
        {
            var controller = new RehberController(_rehberServicesMock.Object);
            Guid guid = new Guid();
            var response = controller.DeleteIletisimBilgisi(guid);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void KisiListesi()
        {
            var controller = new RehberController(_rehberServicesMock.Object);

            var response = controller.KisiListesi();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetIletisimBilgileri()
        {
            var controller = new RehberController(_rehberServicesMock.Object);

            var response = controller.GetIletisimBilgileri();

            Assert.IsNotNull(response);
        }
    }
}
