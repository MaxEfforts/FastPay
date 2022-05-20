
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FastPayDB.Context;


class DatabaseContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        AppConfiguration appConfiguration = new AppConfiguration();
        var opsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        opsBuilder.UseSqlServer(appConfiguration.SqlConnectionString);
        return new ApplicationDbContext(opsBuilder.Options);
    }
}

