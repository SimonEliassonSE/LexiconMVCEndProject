using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LexiconMVCEndProject.Controllers
{
    public class CategoryController : Controller
    {
        readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories;
            if(categories != null)
            {
                return View(categories);
            }
            return View();
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
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category c)
        {
            //c.CategoryId = id;   
            _context.Categories.Update(c);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            Category category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
                return View(category);
            }

            return RedirectToAction("Index");

        }
        

        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);

         
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
        }


    }
}
