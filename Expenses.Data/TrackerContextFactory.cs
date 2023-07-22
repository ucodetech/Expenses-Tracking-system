using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Expenses.Data
{
        public class TrackerContextFactory : IDesignTimeDbContextFactory<TrackerDbContext>
    {
        public TrackerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TrackerDbContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=ExpensesDBase;Trusted_Connection=True;TrustServerCertificate=True;");

            return new TrackerDbContext(optionsBuilder.Options);
        }
    }

    
}