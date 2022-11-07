using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconMVCEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptAPIController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public ReceiptAPIController(ApplicationDbContext context)
        {

            _context = context;

        }
        // GET: api/<ReceiptAPIController>
        [HttpGet]
        public IEnumerable<Receipt> Get()
        {
            return _context.Receipts;
        }

        // GET api/<ReceiptAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReceiptAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReceiptAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReceiptAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
