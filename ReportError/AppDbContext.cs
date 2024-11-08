using Microsoft.EntityFrameworkCore;

namespace ReportError;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Error> Errors { get; set; }
}