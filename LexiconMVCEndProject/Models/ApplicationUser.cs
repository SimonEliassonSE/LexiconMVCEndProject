using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LexiconMVCEndProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Key]
        //public int UserId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public Customer Customer { get; set; }

        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Age { get; set; }
    }
}
