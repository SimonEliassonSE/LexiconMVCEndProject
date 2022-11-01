using LexiconMVCEndProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace LexiconMVCEndProject.Controllers
{
    public class CartController : Controller
    {
        readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display al the items that exist in the cart
        public IActionResult Index()
        {
            var Cart = _context.Carts.ToList();

            return View(Cart);
        }
    }
}
