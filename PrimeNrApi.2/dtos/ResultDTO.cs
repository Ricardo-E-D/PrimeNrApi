using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNrApi._2.dtos
{
    public class ResultDTO
    {
        public string Numbers { get; set; }
        public AddressesDTO Addresses { get; set; }
    }

    public class AddressesDTO
    {
        public string About { get; set; }
        public List<string> Addresses { get; set; }
    }
}
