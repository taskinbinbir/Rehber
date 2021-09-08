using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rapor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapor.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaporController : ControllerBase
    {
        private readonly IRaporServices _raporServices;

        public RaporController(IRaporServices raporServices)
        {
            _raporServices = raporServices;
        }

        [HttpGet("GetRaporlar")]
        public async Task<IActionResult> GetRaporlar()
        {
            return Ok(await _raporServices.GetRapors());
        }

        [HttpGet("DetayRaporTalebi")]
        public async Task<IActionResult> CreateDetayRapor()
        {
            return Ok(await _raporServices.CreateDetayRapor());
        }

        [HttpGet("IstatistikselRaporTalebi")]
        public async Task<IActionResult> CreateIstatistikselRapor()
        {
            return Ok(await _raporServices.CreateIstatistikselRapor());
        }
    }
}
