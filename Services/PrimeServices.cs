using TracerBreaker.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TracerBreaker.Services
{
    public class PrimeService
    {
        private readonly IMongoCollection<Prime> _primes;

        public PrimeService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _primes = database.GetCollection<Prime>(settings.CollectionName);
        }

        public List<Prime> Get() =>
            _primes.Find(prime => true).ToList();

        public void Save(Prime prime)
        {
            _primes.InsertOne(prime);
        }

        public void Save(List<Prime> primes)
        {
            _primes.InsertMany(primes);
        }
    }
}

