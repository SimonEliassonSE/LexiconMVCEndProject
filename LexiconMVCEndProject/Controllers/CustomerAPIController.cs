using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconMVCEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public CustomerAPIController(ApplicationDbContext context)
        {

            _context = context;

        }
        // GET: api/<CustomerAPIController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _context.Customers;
        }

        // GET api/<CustomerAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerAPIController>
        [HttpPost]
        public void Post([FromBody] AddCustomerPostViewModel model)
        {
            var userId = _context.Users.Where(x => x.UserName == model.UserId).ToList();
            ApplicationUser apl = new ApplicationUser();
            foreach(var item in userId)
            {
                apl.Id = item.Id;
                apl.Email = item.Email;
            }

            if(model != null && userId.Count != 0)
            {
                Customer c = new Customer();
                c.FirstName = model.FirstName;
                c.LastName = model.LastName;
                c.PhoneNumber = model.Phonenumber;
                c.Address = model.Address;
                c.ZipCode = model.Zipcode;
                c.City = model.City;
                c.Country = model.Country;
                c.Email = apl.Email;
                c.ApplicationUserId = apl.Id;

                _context.Customers.Add(c);
                _context.SaveChanges();

                Response.StatusCode = 200;
            }
            else if (model == null || userId.Count == 0)
            {
                Response.StatusCode = 400;
            }

        }

        // PUT api/<CustomerAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
