using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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


        [HttpGet]
        public IActionResult AddProducts()
        {
            AddProductsViewModel apVM = new AddProductsViewModel();

            apVM.Products = _context.Products.ToList();

            return View(apVM);
        }



        [HttpPost]
        public async Task<IActionResult> AddProducts(AddProductsViewModel apVM)
        {
            var product = new Product()
            {

                Name = apVM.Name,
                Price = apVM.Price,
                Description = apVM.Description,
                ProductSaldo = apVM.ProductSaldo,
                IMG = apVM.IMG,
                Brand = apVM.Brand,
                CategoryID = apVM.CategoryID,
                Category = apVM.Category,

            };

            await _context.Products.AddAsync(product);
            _context.SaveChanges();


            return RedirectToAction("AddProducts");
        }


        [HttpGet]
        public IActionResult EditProducts(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);

            if (product != null)
            {
                var viewModel = new UpdateProductsViewModel()
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
        public IActionResult EditProducts(UpdateProductsViewModel model)
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
                product.CategoryID = model.CategoryID;

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
