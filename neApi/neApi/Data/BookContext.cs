using Microsoft.EntityFrameworkCore;
using neApi.model;

namespace neApi.Data
{
    public class BookContext:DbContext
    {
   

        public BookContext(DbContextOptions<BookContext> options):base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    





    }
}
