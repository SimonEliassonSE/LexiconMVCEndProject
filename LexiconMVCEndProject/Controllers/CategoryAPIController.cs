using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LexiconMVCEndProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAPIController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public CategoryAPIController(ApplicationDbContext context) { 

            _context = context;

        }


        // GET: api/<CustomerAPIController>/categories
        [HttpGet("categories")]
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }


        // GET: api/<CustomerAPIController>/categories/{id}
        [HttpGet("categories/{id}")]
        public Category GetCategoryById(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            return category;
        }

    }
}
