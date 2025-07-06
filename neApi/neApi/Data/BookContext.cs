using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using neApi.model;

namespace neApi.Data
{
    public class BookContext:IdentityDbContext<ApplicationUser>
    {
   

        public BookContext(DbContextOptions<BookContext> options):base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    





    }
}
