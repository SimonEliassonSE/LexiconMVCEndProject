using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LexiconMVCEndProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {


        readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Product = _context.Products.ToList();

            return View(Product);
        }

        // Behöver ingen _context.Products då vi inte displayar en lista med producter. Vi adderar endast 1 produkt.
        // 
        [HttpGet]
        public IActionResult AddProducts()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");

            AddProductsViewModel apVM = new AddProductsViewModel();

            apVM.Products = _context.Products.ToList();

            return View(apVM);
        }



        [HttpPost]
        public async Task<IActionResult> AddProducts(AddProductsViewModel apVM, int categoryId)
        {
            var product = new Product()
            {

                Name = apVM.Name,
                Price = apVM.Price,
                Description = apVM.Description,
                ProductSaldo = apVM.ProductSaldo,
                IMG = apVM.IMG,
                Brand = apVM.Brand,
                CategoryID = categoryId,
                //Category = apVM.Category,

            };

            await _context.Products.AddAsync(product);
            _context.SaveChanges();


            return RedirectToAction("AddProducts");
        }


        [HttpGet]
        public IActionResult EditProducts(int id)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);

            if (product != null)
            {
                //var viewModel = new UpdateProductsViewModel()
                    var viewModel = new Product()
                    {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    ProductSaldo = product.ProductSaldo,
                    IMG = product.IMG,
                    Brand = product.Brand,
                    CategoryID = product.CategoryID,
                };
                return View("EditProduct", viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditProducts(Product model, int categoryId)
        {
            var product = _context.Products.Find(model.ProductId);

            if (product != null)
            {

                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;
                product.ProductSaldo = model.ProductSaldo;
                product.IMG = model.IMG;
                product.Brand = model.Brand;
                product.CategoryID = categoryId;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }



        public ActionResult DeleteProducts(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            var product = new Product();
            product = _context.Products.FirstOrDefault(x => x.ProductId == id);

            return View(product);
        }

        [HttpGet]
        public IActionResult AddProductToCart()
        {
            CartItemViewModel acVM = new CartItemViewModel();

            acVM.CartItems = _context.CartItems.ToList();

            return View(acVM);
        }


        [HttpPost]
        public async Task<IActionResult> AddProductToCart(int id)
        {
            var product = new Product();
            product = _context.Products.FirstOrDefault(x => x.ProductId == id);

            var cartItem = new CartItem()
            {
                Price = product.Price,

                ProductId = product.ProductId,


            };

            await _context.CartItems.AddAsync(cartItem);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

    }

}
