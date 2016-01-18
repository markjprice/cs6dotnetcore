using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Ch14_WebApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Ch14_WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ShippersController : Controller
    {
        private NorthwindContext db;

        public ShippersController(NorthwindContext injectedContext)
        {
            db = injectedContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Shippers> Get()
        {
            return db.Shippers.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
