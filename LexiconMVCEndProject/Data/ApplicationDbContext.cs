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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

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
                RoleId=adminRoleId,
                UserId=userId,
            });

            //modelBuilder.Entity<Customer>().HasData(new Customer
            //{
            //    CustomerId = 2,
            //    FirstName = "Simon",
            //    LastName = "Eliasson",
            //    Address = "Kvarnberg 12",
            //    ZipCode = "489 21",
            //    City = "Borås",
            //    Country = "Sweden",
            //    Email = "SimonEliasson@gmail.com",
            //    PhoneNumber = "+46 73 456 11 13",
            //    ApplicationUserId = "CarlKarlsson@gmail.com"
            //});
            //modelBuilder.Entity<Category>().HasData(new Category
            //{

            //    CategoryId = 1,
            //    Name = "Headphone",
            //    Description = "Wearable headphones",


            //});

            //modelBuilder.Entity<Product>().HasData(new Product
            //{

            //    ProductId = 1,
            //    Name = "Steelseries 7",
            //    Description = "A pair of Steelseries headset",
            //    Price = 1000,
            //    ProductSaldo = 100,
            //    IMG = "...",
            //    Brand = "Steel Series",
            //    CategoryID = 1,

            //});

            //modelBuilder.Entity<Cart>().HasData(new Cart
            //{
            //    CartId = 1,
            //    TotalPrice = 1000,
            //    CustomerId = 1,

            //});

            //modelBuilder.Entity<CartItem>().HasData(new CartItem
            //{
            //    CartItemId = 1,
            //    Quantity = 1,
            //    Price = 1000,
            //    CartId = 1,
            //    ProductId = 1,

            //});

            //modelBuilder.Entity<CreditCard>().HasData(new CreditCard
            //{
            //    CCId = 1,
            //    CreditNumber = "123 456 789",
            //    CCV = "123",
            //    Bank = "Bank of America",
            //    Value = 10000,
            //    CustomerId = 1,          

            //});

            //modelBuilder.Entity<SalesOrder>().HasData(new SalesOrder
            //{

            //    SalesOrderId = 1,
            //    CartId = 1,
            //    CustomerId = 1,

            //});




        }

    }
}
