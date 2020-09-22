using Microsoft.AspNetCore.Mvc;
using TracerBreaker.Data;
using TracerBreaker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TracerBreaker.Services;
namespace TracerBreaker.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class PrimeController : Controller
    {
        private readonly PrimeService _service;

        public PrimeController(PrimeService service)
        {
            _service = service;
        }


        /*[HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return _context.People.ToList();
        }*/

        [HttpGet("{id}")]
        public List<Prime> GetById(int id)
        {
            return PrimeNumbers.GetPrimes(id);
        }

        [HttpPut("{id}")]
        public string PutById(int id)
        {
            List<Prime> primes = PrimeNumbers.GetPrimes(id);
            _service.Save(primes);
            return "Ok";
        }
    }
}

