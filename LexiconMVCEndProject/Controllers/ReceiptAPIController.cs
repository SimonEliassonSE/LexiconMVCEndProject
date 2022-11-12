using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            //AddReceiptViewModel

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
        public IActionResult Post([FromBody] AddReceiptViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }

            Receipt recipt = new Receipt();
            recipt.CustomerId = model.CustomerId;
            recipt.ReceiptDate = DateTime.Now;
            recipt.OrderDate = DateTime.Now.ToString();
            recipt.TotalCost = model.TotalCost;

            if (recipt != null)
            {
                _context.Receipts.Add(recipt);
                _context.SaveChanges();
            }

            var orderDate = _context.Receipts.Where(x => x.OrderDate == recipt.OrderDate).ToList();

            foreach (var item in orderDate)
            {
                recipt.ReceiptId = item.ReceiptId;
            }
 
            return Ok(recipt.ReceiptId);


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
