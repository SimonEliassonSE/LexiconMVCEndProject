using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconMVCEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptItemAPIController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public ReceiptItemAPIController(ApplicationDbContext context)
        {

            _context = context;
            //AddReceiptItemViewModel

        }
        // GET: api/<ReceiptItemAPIController>
        [HttpGet]
        public IEnumerable<ReceiptItem> Get()
        {
            return _context.ReceiptItems;
        }

        // GET api/<ReceiptItemAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReceiptItemAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] AddReceiptItemViewModel model)
        {
            // write code to create al the required reciptItems!
            if (model == null)
            {
                return NotFound();
            }

            else if(model != null)
            { 

                ReceiptItem ri = new ReceiptItem();
                ri.Name = model.Name;
                ri.Price = model.Price;
                ri.Description = model.Description;
                ri.IMG = model.IMG;
                ri.Brand = model.Brand;
                ri.ReceiptId = model.ReceiptId;

                    if(ri != null)
                    {
                        _context.ReceiptItems.Add(ri);
                        _context.SaveChanges();
                    }

            }

            return Ok();
        }

        // PUT api/<ReceiptItemAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReceiptItemAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
