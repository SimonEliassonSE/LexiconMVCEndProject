using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconMVCEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditcardAPIController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public CreditcardAPIController(ApplicationDbContext context)
        {

            _context = context;

        }
        // GET: api/<CreditcardAPIController>
        [HttpGet]
        public IEnumerable<CreditCard> Get()
        {
            return _context.CreditCards;
        }

        // GET api/<CreditcardAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CreditcardAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CreditcardAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CreditcardAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
