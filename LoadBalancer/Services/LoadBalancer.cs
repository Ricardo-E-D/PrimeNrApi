using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadBalancer.Services
{
    public interface ILoadBalancer
    {
        int GetRandomPort();
        int GetNextPort();
    }
    public class LoadBalancer : ILoadBalancer
    {
        private readonly IConfiguration _configuration;
        private readonly List<int> _addresses;
        public LoadBalancer(IConfiguration configuration)
        {
            _configuration = configuration;
            _addresses = _configuration.GetSection("ServiceAddresses").Get<List<int>>();
        }

        public int GetNextPort()
        {
            var currentAddress = _addresses[0];
            _addresses.Remove(currentAddress);
            _addresses.Add(currentAddress);
            return currentAddress;
        }

        public int GetRandomPort()
        {
            var rnd = new Random();
            return _addresses[rnd.Next(_addresses.Count)];
        }
    }
}
