using LoadBalancer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadBalancer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimeNumberController : ControllerBase
    {
        private readonly IPrimeNumbersSearchService _service;
        public PrimeNumberController(IPrimeNumbersSearchService service)
        {
            _service = service;
        }

        [HttpGet("random/{start}/{end}")]
        public async Task<IActionResult> GetRandom(string start, string end)
        {
            return Ok(await _service.CountPrimesRandom(start, end));
        }

        [HttpGet("roundRobin{start}/{end}")]
        public async Task<IActionResult> GetRoundRobin(string start, string end)
        {
            return Ok(await _service.CountPrimesRoundRobin(start, end));
        }
    }
}
