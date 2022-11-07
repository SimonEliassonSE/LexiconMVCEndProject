using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconMVCEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityAPIController : ControllerBase
    {
        readonly RoleManager<IdentityRole> _roleManager;
        readonly UserManager<ApplicationUser> _userManager;

        public IdentityAPIController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        // GET: api/<IdentityAPIController>
        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            return _userManager.Users;
        }

        // GET api/<IdentityAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IdentityAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<IdentityAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IdentityAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
