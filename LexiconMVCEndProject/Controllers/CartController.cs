using Microsoft.AspNetCore.Mvc;

namespace LexiconMVCEndProject.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
