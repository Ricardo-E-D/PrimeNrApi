using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadBalancer.dtos
{
    public class ResultDTO
    {
        public string Numbers { get; set; }
        public string URL { get; set; }
        public AddressesDTO Addresses { get; set; }
    }

    public class AddressesDTO
    {
        public string About { get; set; }
        public List<string> Addresses { get; set; }
    }
}
