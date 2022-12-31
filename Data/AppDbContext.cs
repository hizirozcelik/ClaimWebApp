using Microsoft.EntityFrameworkCore;
using ClaimWebApp.Models;

namespace ClaimWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<ClaimRequest> ClaimRequests { get; set; }
        public DbSet<ExpenseClaim> ExpenseClaims { get; set; }
        public DbSet<MileageClaim> MileageClaims { get; set; }
        public DbSet<OtherExpenseClaim> OtherExpenseClaims { get; set; }
    }
}
