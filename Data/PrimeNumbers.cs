using System;
using System.Collections.Generic;
using TracerBreaker.Models;

namespace TracerBreaker.Data
{
    public class PrimeNumbers
    {
        public static List<Prime> GetPrimes(int n)
        {
            List<Prime> primeNumbers = new List<Prime>();
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    primeNumbers.Add(new Prime(a));
                    count++;
                }
                a++;
            }
            return primeNumbers;
        }
    }
}
