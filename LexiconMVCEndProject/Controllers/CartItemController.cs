using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
namespace LexiconMVCEndProject.Controllers
{
    public class CartItemController : Controller
    {
        readonly ApplicationDbContext _context;

        public CartItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Cart = _context.CartItems.ToList();

            return View(Cart);
        }


      





    }
}
