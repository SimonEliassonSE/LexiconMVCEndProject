using LexiconMVCEndProject.Data;
using LexiconMVCEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LexiconMVCEndProject.Models;
using Microsoft.EntityFrameworkCore;

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

        static TempCart tempCart = new TempCart();

        public IActionResult Index()
        {
            HomeShopViewModel hsVM = new HomeShopViewModel();

            //var products = _context.Products.ToList();
            var getProducts = _context.Products.ToList();

            hsVM.Products = getProducts;

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
            var product = _context.Products.Where(x => x.ProductId == id).ToList();

            tempCart.productTempList.AddRange(product);

            Product p = new Product();
            foreach(var item in product)
            {
                p.Price = item.Price;
                
            }

            tempCart.TotalPrice = tempCart.TotalPrice + p.Price;

            return RedirectToAction("Index");
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


            return RedirectToAction("CheckOut");
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

            return RedirectToAction("CheckOut");
            //Tested and approved, adds a creditcard to a customer through customerId.
        }


        // This action is redundant, could be removed.
        public IActionResult AddProductNotLoggedin()
        {

            return View();
        }
        // This is the Cart, should display al items and should also validate by checking if user has -->
        // CustomerData, CreditcardData, do a cardvalidation and also check if the creditcard hase enough of cash to cover
        // a user that isent logged in can reatch and see the cart but can not checkout!
        // the cart will be temp until Checkout/buy button is pressed, when pressed validation starts and if validation is -->
        // correct we take the products in TempList and adds them to CartItem --> Cart and starts creating salesorder aswell.
        // There should be a recipt aswell for every purchaes. Dont know where to put that atm. 

        public IActionResult Cart()
        { 

            return View(tempCart);
        }

        public IActionResult RemoveItemTemplist(int id)
        {
            var itemToRemove = tempCart.productTempList.FirstOrDefault(r => r.ProductId == id);
            if (itemToRemove != null) 
            {
                TempCart tc = new TempCart();

                tc.TotalPrice = tempCart.TotalPrice - itemToRemove.Price;

                tempCart.TotalPrice = tc.TotalPrice;

                tempCart.productTempList.Remove(itemToRemove);
            }

            return RedirectToAction("Cart");
        }

        [HttpGet]
        public IActionResult CheckOut()
        {
            //We get the current user (logged in user) with currentUser, if user iis logged in we check if UserId exist in Custom  
            var currentUserId = _userManager.GetUserId(User);

             // If the customer "is" logged in do this
            if (currentUserId != null)
            {          
            // Validerings kod         
            var customerData = _context.Customers.Where(x => x.ApplicationUserId == currentUserId).ToList();

            // If current user dosent have any CustomerData we redirect to AddCustomerData View to let the customer add data
            // customerData will Count the amount of hit's we get! if count is 0 then no customer with that userId was found...
            if (customerData.Count == 0)
            {
                return RedirectToAction("AddCustomerData");
            }

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

            var customerCreditCardData = _context.CreditCards.Where(x => x.CustomerId == c.CustomerId).ToList();

            if (customerData.Count != 0 && customerCreditCardData.Count == 0)
            {
                return RedirectToAction("AddCustomerCreditcardData");
            }

                CreditCard cc = new CreditCard();
                foreach(var item in customerCreditCardData)
                {
                    cc.CCId = item.CCId;   
                    cc.CreditNumber = item.CreditNumber;
                    cc.Bank = item.Bank;                    
                    cc.Value = item.Value;
                    cc.CustomerId = item.CustomerId;
                }

            if(cc.Value >= tempCart.TotalPrice)
            {
                var customerCart = _context.Carts.Where(x => x.CustomerId == c.CustomerId).ToList();
                //var productToAdd = _context.Products.Where(x => x.ProductId == id).ToList();
            
                // Checking if the user has a cart 
                if (customerCart.Count == 0)
                {
                    // If there isent a cart with the current customers userId we create an empty one with only customerId
                    Cart newCart = new Cart();
                    {
                        //newCart.TotalPrice = 0;
                        newCart.CustomerId = c.CustomerId;
                        newCart.TotalPrice = tempCart.TotalPrice;
                    }
                    _context.Carts.Add(newCart);
                    _context.SaveChanges();

                }

                var getNewCart = _context.Carts.Where(x => x.CustomerId == c.CustomerId).ToList();
                //Cart newCart1 = new Cart();
                //CartId ska det vara
                int cartId = 0;
                    foreach (var item in getNewCart)
                    {
                        //newCart1.CustomerId = item.CustomerId;
                        cartId = item.CartId;
                    }

                if(tempCart.productTempList.Count != 0)
                {             
                    for(int i = 0; i < tempCart.productTempList.Count; i++)
                    {
                        CartItem cartItem = new CartItem();

                        cartItem.ProductId = tempCart.productTempList[i].ProductId;
                        cartItem.CartId = cartId;
                        cartItem.Quantity = 1;
                        cartItem.Price = tempCart.productTempList[i].Price;


                        if (cartItem != null)
                        {
                            
                            _context.CartItems.Add(cartItem);
                            _context.SaveChanges();
                        }

                    }



                        //for (int x = 0; x < tempCart.productTempList.Count; x++)
                        //{
                        //    Product product = new Product();

                        //    product.ProductId = tempCart.productTempList[x].ProductId;
                        //    product.Name = tempCart.productTempList[x].Name;
                        //    product.Price = tempCart.productTempList[x].Price;
                        //    product.Description = tempCart.productTempList[x].Description;
                        //    product.ProductSaldo = tempCart.productTempList[x].ProductSaldo - 1;
                        //    product.IMG = tempCart.productTempList[x].IMG;
                        //    product.Brand = tempCart.productTempList[x].Brand;
                        //    product.CategoryID = tempCart.productTempList[x].CategoryID;

                        //    if (product != null)
                        //    {
                        //        _context.Products.Update(product);
                        //        _context.SaveChanges();
                        //    }
                        //}

                        //tempCart.productTempList.Clear();

                        //cc.Value = cc.Value - tempCart.TotalPrice;

                        //_context.CreditCards.Add(cc);
                        //_context.SaveChanges();

                        //tempCart.TotalPrice = 0;
                    };
                    //  In CreateRecipte we will correct productSaldo, Creditcard value, create salesOrder & a recipt.
                    return RedirectToAction("CreateRecipte");


            }
                // Almost done, need to create a salesorder and create a recipie aswell if the value on the card is correct

                

                else if (cc.Value < tempCart.TotalPrice)
                {
                    tempCart.errorMessage = "Your creditcard dosent contain enough money to cover this purchaes";

                    return RedirectToAction("Cart");
                }


                    return RedirectToAction("MyAccount");
            }

            return RedirectToAction("Index");
        }

        public IActionResult MyAccount()
        {
            MyAccountViewModel maVM = new MyAccountViewModel();

            var currentUserId = _userManager.GetUserId(User);

            var customerData = _context.Customers.Where(x => x.ApplicationUserId == currentUserId).ToList();
            
            if(customerData.Count > 0)
            { 
                foreach (var item in customerData)
                {
                    maVM.CustomerId = item.CustomerId;
                    maVM.FirstName = item.FirstName;
                    maVM.LastName = item.LastName;
                    maVM.PhoneNumber = item.PhoneNumber;
                    maVM.Address = item.Address;
                    maVM.ZipCode = item.ZipCode;
                    maVM.City = item.City;
                    maVM.Country = item.Country;
                    maVM.Email = item.Email;
                };
            };

            var customerCreditCardData = _context.CreditCards.Where(x => x.CustomerId == maVM.CustomerId).ToList();

            if(customerCreditCardData.Count > 0)
            {
                foreach(var creditCard in customerCreditCardData)
                {
                    maVM.CCId = creditCard.CCId;
                    maVM.CreditNumber = creditCard.CreditNumber;
                    maVM.CCV = creditCard.CCV;
                    maVM.Bank = creditCard.Bank;
                    maVM.Value = creditCard.Value;
                }
            }


            return View(maVM);
        }

        public IActionResult CreateRecipte()
        {
            var currentUserId = _userManager.GetUserId(User);

            var currentCustomer = _context.Customers.Where(x => x.ApplicationUserId == currentUserId).ToList();

            Customer customer = new Customer();
            foreach (var item in currentCustomer)
            {
                customer.CustomerId = item.CustomerId;
                customer.FirstName = item.FirstName;
                customer.LastName = item.LastName;
                customer.PhoneNumber = item.PhoneNumber;
                customer.Address = item.Address;
                customer.ZipCode = item.ZipCode;
                customer.City = item.City;
                customer.Country = item.Country;
                customer.Email = item.Email;
                customer.ApplicationUserId = item.ApplicationUserId;
            }

            var customerCreditcard = _context.CreditCards.AsNoTracking().Where(x => x.CustomerId == customer.CustomerId).ToList();

            CreditCard creditCard = new CreditCard();

            foreach (var item in customerCreditcard)
            {
 

                creditCard.CCId = item.CCId;
                creditCard.CreditNumber = item.CreditNumber;
                creditCard.CCV = item.CCV;
                creditCard.Bank = item.Bank;
                creditCard.Value = item.Value - tempCart.TotalPrice;
                creditCard.CustomerId = item.CustomerId;

                //_context.Entry(creditCard).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                //_context.Set<CreditCard>().Update(creditCard);
                //_context.CreditCards.Add(creditCard);

                _context.Update(creditCard);
                _context.SaveChanges();
            }

//--------------------------------------- Left 2 do ----------------------------------------------------------
    // We must create a recipt and add the products "bought" and then display it in MyAccount
    // Struggeling currently with the List of strings that should add product information in recipt

            //for (int i = 0; i < tempCart.productTempList.Count; i++)
            //{

            //    var updateProductSaldo = _context.Products.AsNoTracking().Where(x => x.ProductId == tempCart.productTempList[i].ProductId).ToList();

            //    //Product p = new Product();

            //    MyAccountViewModel maVM = new MyAccountViewModel();

            //    // If the same product is added more then 1 time update gives an error saying that EF already is tracking an instance of this...
            //    foreach (var item in updateProductSaldo)
            //    {

            //        maVM.ProductId = item.ProductId.ToString();
            //        maVM.Name = item.Name.ToString();
            //        maVM.Price = item.Price.ToString();
            //        maVM.Description = item.Description.ToString();
            //        //maVM.ProductSaldo = item.ProductSaldo - 1;
            //        //maVM.IMG = item.IMG;
            //        maVM.Brand = item.Brand.ToString();
            //        maVM.CategoryID = item.CategoryID.ToString();


            //        //_context.Products.Update(p);
            //        //_context.SaveChanges();
            //        //maVM.reciptProductsTemp.Add(maVM);
                    

            //    }



            //}

            //var getCart = _context.Carts.AsNoTracking().Where(x => x.CustomerId == customer.CustomerId).ToList();

            //Cart cart = new Cart();
            //foreach(var item in getCart)
            //{
            //    cart.CartId = item.CartId;
            //}

            //SalesOrder salesOrder = new SalesOrder();
            //{
            //    salesOrder.CartId = cart.CartId;
            //    salesOrder.OrderDate = DateTime.Now;

            //    _context.SalesOrders.Add(salesOrder);
            //    _context.SaveChanges();
            //}

            //Receipt receipt = new Receipt();
            //{
            //    receipt.CustomerId = customer.CustomerId;
            //    receipt.ReceiptDate = DateTime.Now;
            //    receipt.OrderDate = salesOrder.OrderDate.ToString();
            //    receipt.TotalCost = tempCart.TotalPrice;               
            //}


            //for(int i = 0; i < tempCart.productTempList.Count; i++)
            //{                
            //    string productId = tempCart.productTempList[i].ProductId.ToString();
            //    receipt.productDetails.Add(productId);

            //    string name = tempCart.productTempList[i].Name.ToString();
            //    receipt.productDetails.Add(name);

            //    string Price = tempCart.productTempList[i].Price.ToString();
            //    receipt.productDetails.Add(Price);

            //    string description = tempCart.productTempList[i].Description.ToString();
            //    receipt.productDetails.Add(description);

            //    string brand = tempCart.productTempList[i].Brand.ToString();
            //    receipt.productDetails.Add(brand);

            //    string categoryId = tempCart.productTempList[i].CategoryID.ToString();
            //    receipt.productDetails.Add(categoryId);
            //}


            // använd Linq för att hämta alla producter där cartId är ... & add to list
            //var querySelect = from p in _context.Products                             
            //                  where p.ProductId == id && cc.CustomerId == customer.CustomerId
            //                  select new


            //receipt.productDetails.Add()

            return RedirectToAction("MyAccount");
        }

    }
}


