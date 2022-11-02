using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LexiconMVCEndProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();            

            return View(customers);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {

            ViewBag.Users = new SelectList(_context.Users , "Id", "Email");

            AddCustomerViewModel acVM = new AddCustomerViewModel();
                
            acVM.Customers = _context.Customers.ToList();

            return View(acVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerViewModel acVM, string userId)
        {
            var userEmail = from user in _context.Users
                            where user.Id == userId
                            select new
                            {
                                userEmail = user.UserName
                            };

            var customer = new Customer()
            {
                //CustomerId = acVM.CustomerId,
                FirstName = acVM.FirstName,
                LastName = acVM.LastName,
                PhoneNumber = acVM.PhoneNumber,
                Address = acVM.Address,
                ZipCode = acVM.ZipCode,
                City = acVM.City,
                Country = acVM.Country,
                ApplicationUserId = userId,       
            };

            foreach (var item in userEmail)
            {
                customer.Email = item.userEmail;
            }

            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();


            return RedirectToAction("AddCustomer");
        }
        // Need 2 update EDIT, added SelectList with user id in create. Edit is still missing this feature..
        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            //ViewBag.Users = new SelectList(_context.Users, "Id", "Email");
            //var customer = await _context.Customers.FirstOrDefault(x =>x.CustomerId == id)
            var customer = _context.Customers.FirstOrDefault(x => x.CustomerId == id);

            if(customer != null)
            {
                //var viewModel = new UpdateCustomerViewModel()
                ViewBag.Users = new SelectList(_context.Users, "Id", "UserName");

                var viewModel = new Customer()
                                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address,
                    ZipCode = customer.ZipCode,
                    City = customer.City,
                    Country = customer.Country,
                    Email = customer.Email,
                    ApplicationUser = customer.ApplicationUser,
                };
                return View("EditCustomer", viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer model,string userId/*UpdateCustomerViewModel model, string userId*/)
        {
            var customer = _context.Customers.Find(model.CustomerId);

            var userEmail = from user in _context.Users
                            where user.Id == userId
                            select new
                            {
                                userEmail = user.UserName
                            };

            if (customer != null)
            {
                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.PhoneNumber = model.PhoneNumber;
                customer.Address = model.Address;
                customer.ZipCode = model.ZipCode;
                customer.City = model.City;
                customer.Country = model.Country;
                //customer.Email = model.Email;
                customer.ApplicationUserId = userId;

                foreach (var item in userEmail)
                {
                    customer.Email = item.userEmail;
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.CustomerId == id);

            if(customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // need to show userId aswell in details.
        [HttpGet]
        public IActionResult CustomerDetails(int id)
        {
            var customer = new Customer();
            customer = _context.Customers.FirstOrDefault(x => x.CustomerId == id);

            return View(customer);
        }

        //[HttpGet]
        //public IActionResult AddCreditcard(int id)
        //{
        //    return View();
        //}


    }
}
