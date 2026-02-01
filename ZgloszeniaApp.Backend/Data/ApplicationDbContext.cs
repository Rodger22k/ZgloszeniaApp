using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZgloszeniaApp.Backend.Models;
using ZgloszeniaApp.Shared.Models;

namespace ZgloszeniaApp.Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Zgloszenie> Zgloszenia { get; set; }
    }
}
