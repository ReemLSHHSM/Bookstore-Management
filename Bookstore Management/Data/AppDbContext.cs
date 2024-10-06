using Bookstore_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Management.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public DbSet<Book> books { get; set; }
    }
}
