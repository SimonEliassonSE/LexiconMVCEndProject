using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LexiconMVCEndProject.Controllers
{
    public class WebShopController : Controller
    {
        readonly ApplicationDbContext _context;

        public WebShopController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            HomeShopViewModel hsVM = new HomeShopViewModel();

            var products = _context.Products.ToList();

            hsVM.Products = products;

            return View(hsVM);
        }

        public IActionResult DisplayHeadphones()
        {
            HomeShopViewModel hsVM = new HomeShopViewModel();

            var products = _context.Products.Where(x => x.CategoryID == 3).ToList();

            hsVM.Products = products;

            return View(hsVM);
        }

        public IActionResult DisplayHeadphoneStands()
        {
            HomeShopViewModel hsVM = new HomeShopViewModel();

            var products = _context.Products.Where(x => x.CategoryID == 5).ToList();

            hsVM.Products = products;

            return View(hsVM);
        }

        public IActionResult DisplayKeyboards()
        {
            HomeShopViewModel hsVM = new HomeShopViewModel();

            var products = _context.Products.Where(x => x.CategoryID == 1).ToList();

            hsVM.Products = products;

            return View(hsVM);
        }

        public IActionResult DisplayComputermouses()
        {
            HomeShopViewModel hsVM = new HomeShopViewModel();

            var products = _context.Products.Where(x => x.CategoryID == 2).ToList();

            hsVM.Products = products;

            return View(hsVM);
        }

    }
}
