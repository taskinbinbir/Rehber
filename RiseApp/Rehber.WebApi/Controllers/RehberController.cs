using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rehber.Core;
using Rehber.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RehberController : ControllerBase
    {
        private readonly IRehberServices _rehberServices;

        public RehberController(IRehberServices rehberServices)
        {
            _rehberServices = rehberServices;
        }           

        [HttpPost("KisiEkle")]
        public IActionResult KisiEkle(KisiModel kisi)
        {
            _rehberServices.AddKisi(kisi);
            return Ok(kisi);
        }

        [HttpDelete("KisiSil/{UUID}")]
        public IActionResult KisiSil(Guid UUID)
        {
            _rehberServices.DeleteKisi(UUID);
            return NoContent();
        }

        [HttpGet("KisiGetir/{UUID}")]
        public IActionResult KisiGetir(Guid UUID)
        {
            return Ok(_rehberServices.GetKisi(UUID));
        }

        [HttpPut("IletisimBilgisiEkle")]
        public IActionResult AddIletisimBilgisi(KisiModel kisi)
        {
            return Ok(_rehberServices.AddIletisimBilgisi(kisi));
        }

        [HttpPut("IletisimBilgisiSil")]
        public IActionResult DeleteIletisimBilgisi(Guid UUID)
        {
            _rehberServices.DeleteIletisimBilgisi(UUID);
            return NoContent();
        }

        [HttpGet("KisiListesi")]
        public IActionResult KisiListesi()
        {
            return Ok(_rehberServices.KisiListesi());
        }

        [HttpGet("IletisimBilgileri")]
        public IActionResult GetIletisimBilgileri()
        {
            return Ok(_rehberServices.KisilerinIletisimBilgileri());
        }
    }
}
