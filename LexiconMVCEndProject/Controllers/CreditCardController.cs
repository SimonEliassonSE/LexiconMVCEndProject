using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVCEndProject.Controllers
{
    [Authorize(Roles = "Admin")]
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
            ViewBag.Customers = new SelectList(_context.Customers, "CustomerId", "FirstName");

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

        [HttpGet]
        public IActionResult EditCreditCard(int id, int customerId)
        {

            var creditCard = _context.CreditCards.FirstOrDefault(x => x.CCId == id);
            ViewBag.Customers = new SelectList(_context.Customers, "CustomerId", "FirstName");


            if (creditCard != null)
            {
                var viewModel = new AddCreditCardViewModel()
                {
                    CCId = creditCard.CCId,
                    CreditNumber = creditCard.CreditNumber, 
                    CCV = creditCard.CCV,   
                    Bank = creditCard.Bank,
                    Value = creditCard.Value,
                    CustomerId = customerId,

                };
                return View("EditCreditCard", viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditCreditCard(AddCreditCardViewModel model)
        {
            var creditCard = _context.CreditCards.Find(model.CCId);

            if (creditCard != null)
            {
                creditCard.CCId = model.CCId;
                creditCard.CreditNumber = model.CreditNumber;
                creditCard.CCV = model.CCV;
                creditCard.Bank = model.Bank;
                creditCard.Value = model.Value;
                creditCard.CustomerId = model.CustomerId;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCreditCard(int id)
        {
            var creditCard = _context.CreditCards.FirstOrDefault(x => x.CCId == id);

            if (creditCard != null)
            {
                _context.CreditCards.Remove(creditCard);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreditCardDetails(int id)
        {
            AddCreditCardViewModel accVM = new AddCreditCardViewModel();

            var querySelect = from cc in _context.CreditCards
                              from customer in _context.Customers
                              where cc.CCId == id && cc.CustomerId == customer.CustomerId
                              select new
                              {
                                  creditCardId = cc.CCId,
                                  customerF = customer.FirstName,
                                  customerL = customer.LastName,
                                  creditcN = cc.CreditNumber,
                                  CCV = cc.CCV,
                                  Bank = cc.Bank,
                                  Value = cc.Value
                              };
           
            foreach (var item in querySelect)
            {
                accVM.CCId = item.creditCardId;
                accVM.FirstName = item.customerF;
                accVM.LastName = item.customerL;
                accVM.CreditNumber = item.creditcN;
                accVM.CCV = item.CCV;
                accVM.Bank = item.Bank;
                accVM.Value = item.Value;
            }

            return View(accVM);
        }

    }
}
