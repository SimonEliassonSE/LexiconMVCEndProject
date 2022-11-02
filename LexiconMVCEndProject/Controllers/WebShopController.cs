using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LexiconMVCEndProject.Models;

namespace LexiconMVCEndProject.Controllers
{
    public class WebShopController : Controller
    {

        readonly ApplicationDbContext _context;
        readonly UserManager<ApplicationUser> _userManager;

        public WebShopController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            HomeShopViewModel hsVM = new HomeShopViewModel();

            var products = _context.Products.ToList();

            hsVM.Products = products;

            return View(hsVM);
        }

        public IActionResult DisplayHeadphones()
        {
            HomeShopViewModel hsVM = new HomeShopViewModel();

            var products = _context.Products.Where(x => x.CategoryID == 3).ToList();

            hsVM.Products = products;

            return View(hsVM);
        }

        public IActionResult DisplayHeadphoneStands()
        {
            HomeShopViewModel hsVM = new HomeShopViewModel();

            var products = _context.Products.Where(x => x.CategoryID == 5).ToList();

            hsVM.Products = products;

            return View(hsVM);
        }

        public IActionResult DisplayKeyboards()
        {
            HomeShopViewModel hsVM = new HomeShopViewModel();

            var products = _context.Products.Where(x => x.CategoryID == 1).ToList();

            hsVM.Products = products;

            return View(hsVM);
        }

        public IActionResult DisplayComputermouses()
        {
            HomeShopViewModel hsVM = new HomeShopViewModel();

            var products = _context.Products.Where(x => x.CategoryID == 2).ToList();

            hsVM.Products = products;

            return View(hsVM);
        }

        // Gets the ID of the product the user wants to add to cart
        public IActionResult AddProductLoggedin (int id)
        {

            //We get the current user (logged in user) with currentUser and check if UserId exist in Custom
            var currentUserId = _userManager.GetUserId(User);
            var customerData = _context.Customers.Where(x => x.ApplicationUserId == currentUserId).ToList();

            // If current user dosent have any CustomerData we redirect to AddCustomerData View to let the customer add data
            // customerData will Count the amount of hit's we get! if count is 0 then no customer with that userId was found...
            if (customerData.Count == 0)
            {
                return RedirectToAction("AddCustomerData");
            }

            Customer c = new Customer();

            // we want to see if current customerId has a creditcard added...
            foreach(var item in customerData)
            {
                c.CustomerId = item.CustomerId;
                c.FirstName = item.FirstName;
                c.LastName = item.LastName;
                c.PhoneNumber = item.PhoneNumber;
                c.Address = item.Address;
                c.ZipCode = item.ZipCode;
                c.City = item.City;
                c.Country = item.Country;
                c.Email = item.Email;
                c.ApplicationUserId = item.ApplicationUserId;
            };

            var customerCreditCardData = _context.CreditCards.Where(x => x.CustomerId == c.CustomerId).ToList();

            if (customerData.Count != 0 && customerCreditCardData.Count == 0)
            {
                return RedirectToAction("AddCustomerCreditcardData");
            }
          

            return View();
        }

        // If user 
        [HttpGet]
        public IActionResult AddCustomerData()
        {         
            return View();

        }

        [HttpPost]
        public IActionResult AddCustomerData(Customer model)
        {

            var currentUserId = _userManager.GetUserId(User);

            Customer c = new Customer();
            { 
            c.FirstName = model.FirstName;
            c.LastName = model.LastName;
            c.PhoneNumber = model.PhoneNumber;
            c.Address = model.Address;
            c.ZipCode = model.ZipCode;
            c.City = model.City;
            c.Country = model.Country;
            c.ApplicationUserId = currentUserId;
        }

            // added this to get the correct Email for the customer
            var userEmail = from user in _context.Users
                            where user.Id == currentUserId
                            select new
                            {
                                userEmail = user.UserName
                            };

            //adds the correct Email to the Customer.
            foreach (var item in userEmail)
            {
                c.Email = item.userEmail;
            }

            _context.Customers.Add(c);
            _context.SaveChanges();


            return RedirectToAction("AddProductLoggedin");
            //Tested and approved, adds a customer with user ID and gets the correct E-mail.

        }
        [HttpGet]
        public IActionResult AddCustomerCreditcardData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomerCreditcardData(CreditCard model)
        {
            var currentUserId = _userManager.GetUserId(User);
            var customerData = _context.Customers.Where(x => x.ApplicationUserId == currentUserId).ToList();

            Customer c = new Customer();

            // we want to see if current customerId has a creditcard added...
            foreach (var item in customerData)
            {
                c.CustomerId = item.CustomerId;
                c.FirstName = item.FirstName;
                c.LastName = item.LastName;
                c.PhoneNumber = item.PhoneNumber;
                c.Address = item.Address;
                c.ZipCode = item.ZipCode;
                c.City = item.City;
                c.Country = item.Country;
                c.Email = item.Email;
                c.ApplicationUserId = item.ApplicationUserId;
            };

            // Get customerId here...
            Random rand = new Random();
            double randomValue = rand.Next(1, 10000);

            CreditCard creditCard = new CreditCard();
            {
                // We will "take" CreditNumber, CCV and Bank from user, the rest will be Auto Generated.
                creditCard.CreditNumber = model.CreditNumber;
                creditCard.CCV = model.CCV;
                creditCard.Bank = model.Bank;
                // We will be using a randomiser to get a random value on the amount of moneye the card contains.
                creditCard.Value = randomValue;
                creditCard.CustomerId = c.CustomerId;
            }

            _context.CreditCards.Add(creditCard);
            _context.SaveChanges();

            return RedirectToAction("AddProductLoggedin");
            //Tested and approved, adds a creditcard to a customer through customerId.
        }



        public IActionResult AddProductNotLoggedin()
        {

            return View();
        }

    }
}
