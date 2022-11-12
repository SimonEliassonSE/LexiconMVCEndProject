using LexiconMVCEndProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace LexiconMVCEndProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptItem> ReceiptItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();
            string userId2 = Guid.NewGuid().ToString();
            string userId3 = Guid.NewGuid().ToString();
            string userId4 = Guid.NewGuid().ToString();


            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",

            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER",
            });

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PasswordHash = hasher.HashPassword(null, "password")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = userId,
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId2,
                Email = "test1@test.se",
                NormalizedEmail = "TEST1@TEST.SE",
                UserName = "test1@test.se",
                NormalizedUserName = "TEST1@TEST.SE",
                PasswordHash = hasher.HashPassword(null, "test1")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = userRoleId,
                UserId = userId2,
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId3,
                Email = "test2@test.se",
                NormalizedEmail = "TEST2@TEST.SE",
                UserName = "test2@test.se",
                NormalizedUserName = "TEST2@TEST.SE",
                PasswordHash = hasher.HashPassword(null, "test2")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = userRoleId,
                UserId = userId3,
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId4,
                Email = "test4@test.se",
                NormalizedEmail = "TEST4@TEST.SE",
                UserName = "test4@test.se",
                NormalizedUserName = "TEST4@TEST.SE",
                PasswordHash = hasher.HashPassword(null, "test4")
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = userRoleId,
                UserId = userId4,
            });


            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstName = "Anders",
                LastName = "Karlsson",
                PhoneNumber = "073 888 54 12",
                Address = "Björnidet 13",
                ZipCode = "123 90",
                City = "Björneborg",
                Country = "Sweden",
                Email = "test1@test.se",
                ApplicationUserId = userId2,
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                FirstName = "Karin",
                LastName = "Svensson",
                PhoneNumber = "074 123 97 41",
                Address = "Medborgargatan 39",
                ZipCode = "782 21",
                City = "Malmö",
                Country = "Sweden",
                Email = "test2@test.se",
                ApplicationUserId = userId3,
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 3,
                FirstName = "Sune",
                LastName = "Stig",
                PhoneNumber = "077 564 28 31",
                Address = "Björkvägen 89",
                ZipCode = "329 85",
                City = "Karlstad",
                Country = "Sweden",
                Email = "test4@test.se",
                ApplicationUserId = userId4,
            });

            modelBuilder.Entity<CreditCard>().HasData(new CreditCard
            {
                CCId = 1,
                CreditNumber = "4566 3621 3658 7895",
                CCV = "852",
                Bank = "Nordea",
                Value = 20000,
                CustomerId = 1,
            });

            modelBuilder.Entity<CreditCard>().HasData(new CreditCard
            {
                CCId = 2,
                CreditNumber = "7521 1245 3652 8541",
                CCV = "963",
                Bank = "Swedbank",
                Value = 30000,
                CustomerId = 2,
            });

            modelBuilder.Entity<CreditCard>().HasData(new CreditCard
            {
                CCId = 3,
                CreditNumber = "7596 8521 4563 8514",
                CCV = "248",
                Bank = "Bank of America",
                Value = 50000,
                CustomerId = 3,
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                Name = "Keyboard",
                Description = "Diffrent kind's of keyboards",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 2,
                Name = "Computer Mouse",
                Description = "Diffrent kind's of computer mouses",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 3,
                Name = "Headphone",
                Description = "Diffrent kind's of headphones",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 4,
                Name = "Headphonestand",
                Description = "Diffrent kind's of headphonestands",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Arc 100XT",
                Price = 1299,
                Description = "Thundercats High end gaming headset for the ultimate gaming experience!",
                ProductSaldo = 100,
                IMG = "/Images/Headphones1.jpg",
                Brand = "Thundercat",
                CategoryID = 3,

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Thunder 75Z",
                Price = 899,
                Description = "Thundercats Mind tier gaming headset",
                ProductSaldo = 180,
                IMG = "/Images/Headphones2.jpg",
                Brand = "Thundercat",
                CategoryID = 3,

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Zero C100",
                Price = 1599,
                Description = "Siberia's High end gaming headset for the ultimate gaming experience!",
                ProductSaldo = 50,
                IMG = "/Images/Headphones3.jpg",
                Brand = "Siberia",
                CategoryID = 3,

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "ZummerXT30",
                Price = 599,
                Description = "Siberia's allround headset for gaming and daily use!",
                ProductSaldo = 50,
                IMG = "/Images/Headphones4.jpg",
                Brand = "Siberia",
                CategoryID = 3,

            });


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "Session1",
                Price = 2999,
                Description = "StudioFactory's top of the line studio recording headset",
                ProductSaldo = 30,
                IMG = "/Images/Headphones5.jpg",
                Brand = "StudioFactory",
                CategoryID = 3,

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                Name = "Model3",
                Price = 799,
                Description = "Robust headphonestand made with stainless steel and wood",
                ProductSaldo = 90,
                IMG = "/Images/HeadphoneStand1.jpg",
                Brand = "Steeldesign",
                CategoryID = 4,
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                Name = "Krillin8000",
                Price = 499,
                Description = "basic keyboard from GohanStudio",
                ProductSaldo = 200,
                IMG = "/Images/Keyboard1.png",
                Brand = "GohanStudio",
                CategoryID = 1,

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 8,
                Name = "Gohan10x",
                Price = 999,
                Description = "Mid tier gaming keyboard from Ghohanstudio",
                ProductSaldo = 90,
                IMG = "/Images/Keyboard2.png",
                Brand = "GohanStudio",
                CategoryID = 1,

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 9,
                Name = "Goku9000",
                Price = 1200,
                Description = "High end gaming keyboard from Ghohanstudio for the ultimate gaming experience!",
                ProductSaldo = 50,
                IMG = "/Images/Keyboard3.jpg",
                Brand = "GohanStudio",
                CategoryID = 1,

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 10,
                Name = "33SpeedDemon",
                Price = 599,
                Description = "Mid tier gaming mouse from tundra with 3 speed level's",
                ProductSaldo = 98,
                IMG = "/Images/Mouse1.jpg",
                Brand = "Tundra",
                CategoryID = 2,

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 11,
                Name = "NineCA3",
                Price = 799,
                Description = "Mid tier gaming mouse from tundra",
                ProductSaldo = 120,
                IMG = "/Images/Mouse2.png",
                Brand = "Tundra",
                CategoryID = 2,

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 12,
                Name = "TP3",
                Price = 399,
                Description = "Basic alaround keyboard from tundra",
                ProductSaldo = 200,
                IMG = "/Images/Mouse3.png",
                Brand = "Tundra",
                CategoryID = 2,

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 13,
                Name = "X-0",
                Price = 1100,
                Description = "High end gaming mouse from tundra",
                ProductSaldo = 60,
                IMG = "/Images/Mouse4.png",
                Brand = "Tundra",
                CategoryID = 2,
            });

//-----------------------------------------------------------------------------------------------------------
        // <------ This code below dose not work ---------->

            // If you want a Customer to have a cart with items please log in to for example
            // test1@test.se (pw test), add some products to cart and checkout. Then cart will be created
            // with items and a total value

            //modelBuilder.Entity<Cart>().HasData(new Cart
            //{
            //    CartId = 1,
            //    CustomerId = 1,
            //});

            //modelBuilder.Entity<CartItem>().HasData(new CartItem
            //{
            //    CartItemId = 1,
            //    Quantity = 2,
            //    Price = 1299,
            //    CartId = 1,
            //    ProductId = 1,

            //});

            //modelBuilder.Entity<CartItem>().HasData(new CartItem
            //{
            //    CartItemId = 2,
            //    Quantity = 1,
            //    Price = 1299,
            //    CartId = 1,
            //    ProductId = 1,

            //});

            //modelBuilder.Entity<CartItem>().HasData(new CartItem
            //{
            //    CartItemId = 3,
            //    Quantity = 1,
            //    Price = 1100,
            //    CartId = 1,
            //    ProductId = 13,

            //});

            //modelBuilder.Entity<CartItem>().HasData(new CartItem
            //{
            //    CartItemId = 4,
            //    Quantity = 1,
            //    Price = 1200,
            //    CartId = 1,
            //    ProductId = 9,

            //});

        }

    }
}
