using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using practice_12_october.Models;

namespace practice_12_october.Data
{
    public class ApplicationDbContext : IdentityDbContext <Register>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<practice_12_october.Models.ArgentineCow> ArgentineCow { get; set; } = default!;
        public DbSet<practice_12_october.Models.ManageCow> ManageCow { get; set; } = default!;
        public DbSet<practice_12_october.Models.HealthRecord> HealthRecord { get; set; } = default!;
        


    }
}

