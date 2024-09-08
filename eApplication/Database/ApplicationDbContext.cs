using eApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace eApplication.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Todo> Todos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>()
            .HasKey(x => x.Id).IsClustered();
    }
}