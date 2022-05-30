using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNrApi.Services
{
    public interface IPrimeNumbersSearchService
    {
        string CountPrimes(string start, string end);
    }

    public class PrimeNumbersSearchService : IPrimeNumbersSearchService
    {
        // Find the prime numbers between 2 numbers.
        // takes two string as search parameters.
        public string CountPrimes(string start, string end)
        {
            int sayac = 0;
            string primes = "";
            Int64 startNr = Convert.ToInt64(start);
            Int64 endNr = Convert.ToInt64(end);
            Int64 nrOfPrimes = 0;

            for (Int64 i = startNr; i < endNr; i++)
            {
                sayac = 0;
                if (i > 1)
                {
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            sayac = 1;
                            break;
                        }
                    }
                    if (sayac == 0)
                    {
                        primes += i.ToString() + ", ";
                        nrOfPrimes++;
                    }
                }
            }
            return primes;
        }
    }
}
