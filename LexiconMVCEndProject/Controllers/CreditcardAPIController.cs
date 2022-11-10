using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
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
        public void Post([FromBody] CreateCreditcardPostViewModel model)
        {
            
            if(model != null)
            { 
            CreditCard cc = new CreditCard();

            Random rand = new Random();
            int rand_value = rand.Next(0, 100000);

            cc.CreditNumber = model.CreditNumber;
            cc.CCV = model.CCV;
            cc.Bank = model.Bank;
            cc.CustomerId = model.CustomerId;
            cc.Value = rand_value;

                _context.Add(cc);
                _context.SaveChanges();

                Response.StatusCode = 200;
            }
            else
            {
                Response.StatusCode = 400;
            }
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
