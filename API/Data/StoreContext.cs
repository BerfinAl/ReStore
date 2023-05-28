using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

// our dbset represents a table in our database. and 
// we"re gonna have a table for products
// and each of the properties inside product represent a column in product  table
        public DbSet<Product> Products { get; set; }
    }
}