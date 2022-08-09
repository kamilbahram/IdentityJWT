using IdentityJWT.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private AppIdentityDbContex context;

        public ValuesController(AppIdentityDbContex context )
        {
            this.context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return context.Users.Select(x => x.UserName).ToArray();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
