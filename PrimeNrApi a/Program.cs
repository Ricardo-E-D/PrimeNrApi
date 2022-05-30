using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PrimeNrApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
//namespace PrimeNrApp
//{

//    class Program
//    {
//        static void Main()
//        {
//            string choice = "";
//            while (choice != "q")
//            {
//                Console.WriteLine("---------------------------------");
//                Console.WriteLine("-- a: run IsPrime method.      --");
//                Console.WriteLine("-- b: run CountPrimes method.  --");
//                Console.WriteLine("-- q: to quit program.         --");
//                Console.WriteLine("---------------------------------");

//                choice = Console.ReadLine();
//                if (choice == "a")
//                {
//                    Console.Clear();
//                    Console.WriteLine("Write your Nr.");
//                    string input = Console.ReadLine();
//                    try
//                    {
//                        IsPrime(input);
//                    }
//                    catch (Exception e)
//                    {
//                        Console.WriteLine(e);
//                    }
//                }
//                else if (choice == "b")
//                {
//                    Console.Clear();
//                    Console.WriteLine("Write start nr.");
//                    string startNr = Console.ReadLine();
//                    Console.WriteLine("Write ending nr.");
//                    string endNr = Console.ReadLine();

//                    try 
//                    { 
//                        CountPrimes(startNr, endNr); 
//                    }
//                    catch(Exception f)
//                    {
//                        Console.WriteLine(f);
//                    }
//                }

//            }
//        }

//        /**
//         *  Check if the number is prime,
//         *  return true or false based on the result.
//         */
//        static bool IsPrime(string nr)
//        {
//            Int64 n = Convert.ToInt64(nr);

//            if (n == 2 || n == 3)
//            {
//                Console.WriteLine("true");
//                return true;
//            }

//            if (n <= 1)
//            {
//                Console.WriteLine("false");
//                return false;
//            }
//            if(n % 2 == 0)
//            {
//                Console.WriteLine("false. it is divisible by 2");
//                return false;
//            }
//            if(n % 3 == 0)
//            {
//                Console.WriteLine("false. it is divisible by 3");
//                return false;
//            }

//            for (int i = 5; i * i <= n; i += 6)
//            {
//                if (n % i == 0)
//                {
//                    Console.WriteLine("false. it is divisible by " + i);
//                    return false;
//                }
//                if(n % (i + 2) == 0)
//                {
//                    Console.WriteLine("false. it is divisible by " + (i+2));
//                    return false;
//                }
//            }

//            Console.WriteLine("true");
//            return true;
//        }
//        /**
//         *  Find the prime numbers between 2 numbers.
//         *  takes two string as search parameters.
//         */
//        public static string CountPrimes(string start, string end) 
//        {
//            int sayac = 0;
//            string primes = "";
//            Int64 startNr = Convert.ToInt64(start);
//            Int64 endNr = Convert.ToInt64(end);
//            Int64 nrOfPrimes = 0;

//            Console.WriteLine("Prime numbers between {0} and {1} are: ", start, end);

//            for (Int64 i = startNr; i < endNr; i++)
//            {
//                sayac = 0;
//                if (i > 1)
//                {
//                    for (int j = 2; j < i; j++)
//                    {
//                        if (i % j == 0)
//                        {
//                            sayac = 1;
//                            break;
//                        }
//                    }
//                    if (sayac == 0)
//                    {
//                        primes += i.ToString() + ", ";
//                        Console.WriteLine(i);
//                        nrOfPrimes++;
//                    }
//                }
//            }
//            Console.Clear();
//            Console.WriteLine(primes);
//            Console.WriteLine("");
//            Console.WriteLine("There is " + nrOfPrimes + " prime numbers inbetween " + start + " and " + end);

//            return primes;
//        }
//    }
//}
