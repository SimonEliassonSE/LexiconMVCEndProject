using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVCEndProject.Controllers
{

    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            //if(categories != null)
            //{
                return View(categories);
            //}
            //return View();
        }

        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        public IActionResult Create(Category category)
        {
            ModelState.Remove("Products");

            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                // Added a RedirectToAtion since previus config caused an error (The index is missing a way to display the "ViewBag")
                return RedirectToAction("Index");
            }

            ViewBag.Statement = "A new category has been added.";
            return RedirectToAction("Index", ViewBag.Statement);
        }


        // Code needs to be reworked. When you edit a new"category" (not edit, more like create atm)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);

            if (category != null)
            {

                var viewModel = new Category()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                };
                return View("Edit", viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            var category = _context.Categories.Find(model.CategoryId);

            if (category != null)

            {

                category.Name = model.Name;
                category.Description = model.Description;
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");

        }

        //[HttpPost]
        //public IActionResult EditCustomer(Customer model, string userId/*UpdateCustomerViewModel model, string userId*/)
        //{
        //    var customer = _context.Customers.Find(model.CustomerId);

        //    var userEmail = from user in _context.Users
        //                    where user.Id == userId
        //                    select new
        //                    {
        //                        userEmail = user.UserName
        //                    };

        //    if (customer != null)
        //    {
        //        customer.FirstName = model.FirstName;
        //        customer.LastName = model.LastName;
        //        customer.PhoneNumber = model.PhoneNumber;
        //        customer.Address = model.Address;
        //        customer.ZipCode = model.ZipCode;
        //        customer.City = model.City;
        //        customer.Country = model.Country;
        //        //customer.Email = model.Email;
        //        customer.ApplicationUserId = userId;

        //        foreach (var item in userEmail)
        //        {
        //            customer.Email = item.userEmail;
        //        }

        //        _context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    return RedirectToAction("Index");
        //}

        // Delete dose not work on Edit Bugg.
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);

            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        //public ActionResult DeleteCustomer(int id)
        //{
        //    var customer = _context.Customers.FirstOrDefault(x => x.CustomerId == id);

        //    if (customer != null)
        //    {
        //        _context.Customers.Remove(customer);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public IActionResult ShowProductsInCategory(int id)
        {

            var categories = _context.Categories.Find(id);

            var products = _context.Products.Where(x => x.CategoryID == id).ToList();

            if(categories != null)
            { 

                if(products != null)
                {

                    foreach (var item in products)
                    {
                        categories.Products.Add(item);
                    }

                    return View(categories);
                }

            }

            return RedirectToAction("Index");



        }
    }
}
