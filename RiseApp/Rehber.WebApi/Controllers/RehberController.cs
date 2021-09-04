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

        [HttpDelete("KisiSil/{id}")]
        public IActionResult KisiSil(Guid id)
        {
            _rehberServices.DeleteKisi(id);
            return NoContent();
        }

        [HttpGet("KisiGetir/{id}")]
        public IActionResult KisiGetir(Guid id)
        {
            return Ok(_rehberServices.GetKisi(id));
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
