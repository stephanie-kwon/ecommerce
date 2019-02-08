using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Models

{
    public class YourContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public YourContext(DbContextOptions<YourContext> Ecommerce) : base(Ecommerce) { }
      
        public DbSet<Item> Items {get;set;}
        public DbSet<CartItem> ShoppingCartItems {get;set;}

        public DbSet<User> Users {get;set;}
        public DbSet<Bought> boughtProds {get;set;}
    }
}
