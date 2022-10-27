using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVCEndProject.Controllers
{
    public class CreditCardController : Controller
    {
        readonly ApplicationDbContext _context;

        public CreditCardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var creditCard = _context.CreditCards.Include(x => x.Customer).ToList();

            return View(creditCard);

        }


        //public IActionResult AddCreditcard()
        //{


        //    return View();
        //}

        public IActionResult AddCreditcard()
        {
            ViewBag.Customers = new SelectList(_context.Customers, "CustomerId", "FirstName", "LastName");

            AddCreditCardViewModel accVM = new AddCreditCardViewModel();

            accVM.Creditcards = _context.CreditCards.Include(x => x.Customer).ToList();

            return View(accVM);
        }

        [HttpPost]
        public IActionResult AddCreditcard(AddCreditCardViewModel accVM, int customerId)
        {
            //if (ModelState.IsValid)
            //{
                var creditCard = new CreditCard()
                {
                    CreditNumber = accVM.CreditNumber,
                    CCV = accVM.CCV,
                    Bank = accVM.Bank,
                    Value = accVM.Value,
                    CustomerId = customerId,
                };
                _context.CreditCards.Add(creditCard);
                _context.SaveChanges();

                return RedirectToAction("AddCreditcard");
            //}


            //return RedirectToAction("AddCreditcard");
        }
    }
}
