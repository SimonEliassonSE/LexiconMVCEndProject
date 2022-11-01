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

        [HttpGet]
        public IActionResult ShowProductsInCategory(int id)
        {

            //HomeShopViewModel hsVM = new HomeShopViewModel();

            //var products = _context.Products.Where(x => x.CategoryID == 3).ToList();

            //hsVM.Products = products;

            //return View(hsVM);

            Category c = new Category();

            var products = _context.Products.Where(x => x.CategoryID == id).ToList();

            c.Products = products;

            var categorie = _context.Categories.Where(x => x.CategoryId == id);

            foreach(var item in categorie)
            {
                c.CategoryId = item.CategoryId;
                c.Name = item.Name;
            }


            return View(c);

            //var categories = _context.Categories.Find(id);

            //var products = _context.Products.Where(x => x.CategoryID == id).ToList();

            //if(categories != null)
            //{ 

            //    if(products != null)
            //    {

            //        foreach (var item in products)
            //        {
            //            categories.Products.Add(item);
            //        }

            //        return View(categories);
            //    }

            //}

            //return RedirectToAction("Index");



        }
    }
}
