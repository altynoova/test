using Microsoft.EntityFrameworkCore;
using test;

public class ApplicationDBContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
             : base(options)
    {
        Database.EnsureCreated();   
    }
}