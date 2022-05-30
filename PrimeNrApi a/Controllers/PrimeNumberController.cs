using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using PrimeNrApi.dtos;
using PrimeNrApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNrApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimeNumberController : ControllerBase
    {
        private readonly IPrimeNumbersSearchService _service;
        private readonly IServer _server;

        public PrimeNumberController(IPrimeNumbersSearchService service, IServer server)
        {
            _service = service;
            _server = server;
        }

        [HttpGet("{start}/{end}")]
        public IActionResult Get(string start, string end)
        {
            var addresses = _server.Features.Get<IServerAddressesFeature>().Addresses;

            return Ok(new ResultDTO()
            {
                Numbers = _service.CountPrimes(start, end),
                Addresses = new AddressesDTO()
                {
                    About = "This information comes from the PrimeNrApi service",
                    Addresses = addresses.ToList()
                }
            });
        }
    }
}
