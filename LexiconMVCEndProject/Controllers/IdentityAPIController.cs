using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
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
        readonly ApplicationDbContext _context;

        public IdentityAPIController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {         
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
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
        public ApplicationUser Post([FromBody] CreateUserViewModel cuVM)
        {
            var checkcuVM = _userManager.Users.Where(x => x.UserName == cuVM.UserName).ToList();

            ApplicationUser apUser = new ApplicationUser();

            // If the checkcuVM is empty go ahead and try to create a new user.
            if (checkcuVM.Count == 0)
            {        

                    PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();  

                    apUser.UserName = cuVM.UserName;
                    apUser.NormalizedUserName = cuVM.UserName.ToUpper();
                    apUser.Email = cuVM.UserName;
                    apUser.NormalizedEmail = cuVM.UserName.ToUpper();
                    apUser.PasswordHash = hasher.HashPassword(null, cuVM.Password);
           

                    if (apUser != null)
                    { 
                    _context.Users.Add(apUser);
                    _context.SaveChanges();

                        var currentUser = _userManager.Users.Where(x => x.UserName == cuVM.UserName).ToList();
                        ApplicationUser checkapUser = new ApplicationUser();
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

                        PasswordVerificationResult passresult = _userManager.PasswordHasher.VerifyHashedPassword(apUser, apUser.PasswordHash, cuVM.Password);
                        var temp = passresult.ToString();

                        if (temp == "Success")
                        {
                            Response.StatusCode = 200;

                        }

                        else if(temp == "Failed")
                        {
                            Response.StatusCode = 400;
                        }
            
                    }
            }
            else
            {
                // A account with this username already exist
                Response.StatusCode = 400;
            }

            return apUser;
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
