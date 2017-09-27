using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers
{
    [Produces("application/json")]
    [Route("api/Base")]
    public abstract class BaseController : Controller
    {
        // GET: api/Base
        [HttpGet]
        public virtual IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Base/5
        [HttpGet("{id}", Name = "Get")]
        public virtual string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Base
        [HttpPost]
        public virtual void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Base/5
        [HttpPut("{id}")]
        public virtual void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public virtual void Delete(int id)
        {
        }
    }
}
