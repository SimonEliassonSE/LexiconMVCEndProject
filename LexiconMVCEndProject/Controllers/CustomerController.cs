using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.Models;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            AddCustomerViewModel acVM = new AddCustomerViewModel();
                
            acVM.Customers = _context.Customers.ToList();

            return View(acVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerViewModel acVM)
        {
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
                Email = acVM.Email,

            };

            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();


            return RedirectToAction("AddCustomer");
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            //var customer = await _context.Customers.FirstOrDefault(x =>x.CustomerId == id)
            var customer = _context.Customers.FirstOrDefault(x => x.CustomerId == id);

            if(customer != null)
            {
                var viewModel = new UpdateCustomerViewModel()
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
                };
                return View("EditCustomer", viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditCustomer(UpdateCustomerViewModel model)
        {
            var customer = _context.Customers.Find(model.CustomerId);

            if(customer != null)
            {

                customer.FirstName = model.FirstName;
                customer.LastName = model.LastName;
                customer.PhoneNumber = model.PhoneNumber;
                customer.Address = model.Address;
                customer.ZipCode = model.ZipCode;
                customer.City = model.City;
                customer.Country = model.Country;
                customer.Email = model.Email;

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
