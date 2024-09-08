using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace eApplication.Database;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-JKTO23G;Initial Catalog=TaskApplication;Integrated Security=True;Trust Server Certificate=True");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}