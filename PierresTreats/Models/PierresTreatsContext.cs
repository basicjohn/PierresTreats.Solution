using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PierresTreats.Models
{
  public class PierresTreatsContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Flavor> Flavor { get; set; }
    public DbSet<Treat> Treat { get; set; }
    public DbSet<FlavorTreat> FlavorTreat { get; set; }
    public DbSet<Patron> Patron { get; set; }
    public DbSet<Checkout> Checkout { get; set; }

    public PierresTreatsContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}