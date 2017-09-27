using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using RestService.Models;
using System.Net;

namespace RestService.Controllers
{
    [Produces("application/json")]
    [Route("api/Person")]
    public class PersonController : Controller
    {
        // GET: api/Person
        [HttpGet]
        public IEnumerable<PersonRest> Get()
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return new List<PersonRest>()
            {
                new PersonRest() { FName = "Leon", LName = "Moore" },
                new PersonRest() { FName = "Fred", LName = "Bellote" },
                new PersonRest() { FName = "Zach", LName = "Moore" }
            };
        }

        //public HttpResponseMessage Get()
        //{
        //    return Request.CreateResponse<T>(HttpStatusCode.OK, new List<PersonRest>()
        //    {
        //        new PersonRest() { FName = "Leon", LName = "Moore" }
        //    });
        //}

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Person
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
