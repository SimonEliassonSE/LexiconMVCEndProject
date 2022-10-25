using LexiconMVCEndProject.Models;
using Microsoft.EntityFrameworkCore;


namespace LexiconMVCEndProject.Data
{
    public class ApplicationDbContext : DbContext
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
        public DbSet<SalesOrder> SalesOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstName = "Carl",
                LastName = "Karlsson",
                Address = "Solängen 11",
                ZipCode = "511 20",
                City = "Kungsbacka",
                Country = "Sweden",
                Email = "CarlKarlsson@gmail.com",
                PhoneNumber = "+46 72 382 82 17"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {

                CategoryId = 1,
                Name = "Headphone",
                Description = "Wearable headphones",

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {

                ProductId = 1,
                Name = "Steelseries 7",
                Description = "A pair of Steelseries headset",
                Price = 1000,
                ProductSaldo = 100,
                IMG = "...",
                Brand = "Steel Series",
                CategoryID = 1,
               
            });

            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                CartId = 1,
                TotalPrice = 1000,
                CustomerId = 1,

            });

            modelBuilder.Entity<CartItem>().HasData(new CartItem
            {
                CartItemId = 1,
                Quantity = 1,
                Price = 1000,
                CartId = 1,
                ProductId = 1,

            });


            modelBuilder.Entity<SalesOrder>().HasData(new SalesOrder
            {
                
                SalesOrderId = 1,
                CartId = 1,
                CustomerId = 1,

            });




        }

    }
}
