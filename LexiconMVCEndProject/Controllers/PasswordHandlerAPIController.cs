using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconMVCEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordHandlerAPIController : ControllerBase
    {

        readonly RoleManager<IdentityRole> _roleManager;
        readonly UserManager<ApplicationUser> _userManager;

        public PasswordHandlerAPIController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        // GET: api/<PasswordHandlerAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PasswordHandlerAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PasswordHandlerAPIController>
        [HttpPost]
        //public void Post([FromBody] string userName, string password)
        public string Post([FromBody] PasswordHandlerViewModel phVM)
        {
            //
            // Summary:
            //     Indicates password verification failed.
            // -->Failed,
            //
            // Summary:
            //     Indicates password verification was successful.
            // -->Success,
            //
            // Summary:
            //     Indicates password verification was successful however the password was encoded
            //     using a deprecated algorithm and should be rehashed and updated.
            // --> SuccessRehashNeeded

            var currentUser = _userManager.Users.Where(x => x.UserName == phVM.UserName).ToList();
            ApplicationUser apUser = new ApplicationUser();
            foreach (var item in currentUser)
            {
                apUser.Id = item.Id;
                apUser.UserName = item.UserName;
                apUser.NormalizedUserName = item.NormalizedUserName;
                apUser.Email = item.Email;
                apUser.NormalizedEmail = item.NormalizedEmail;
                apUser.EmailConfirmed = item.EmailConfirmed;
                apUser.PasswordHash = item.PasswordHash;
                apUser.PhoneNumber = item.PhoneNumber;
                apUser.PhoneNumberConfirmed = item.PhoneNumberConfirmed;
                apUser.SecurityStamp = item.SecurityStamp;
                apUser.ConcurrencyStamp = item.ConcurrencyStamp;
                apUser.TwoFactorEnabled = item.TwoFactorEnabled;
                apUser.LockoutEnd = item.LockoutEnd;
                apUser.LockoutEnabled = item.LockoutEnabled;
                apUser.AccessFailedCount = item.AccessFailedCount;
            }

            PasswordVerificationResult passresult = _userManager.PasswordHasher.VerifyHashedPassword(apUser, apUser.PasswordHash, phVM.Password);
            // Build code to handle success & Fail. in the if statement we can Convert ToString to see if passresult == sucess or failed.
            return passresult.ToString();     
        }

        // PUT api/<PasswordHandlerAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PasswordHandlerAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
