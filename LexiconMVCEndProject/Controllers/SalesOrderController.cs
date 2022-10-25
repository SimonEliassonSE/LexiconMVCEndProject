using Microsoft.AspNetCore.Mvc;

namespace LexiconMVCEndProject.Controllers
{
    public class SalesOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
