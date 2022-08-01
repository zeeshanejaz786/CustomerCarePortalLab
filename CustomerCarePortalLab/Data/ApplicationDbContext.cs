using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CustomerCarePortalLab.Models;
namespace CustomerCarePortalLab.Data
    {
    public class ApplicationDbContext : IdentityDbContext
        {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options )
            : base( options )
            {
            }
        public DbSet<Agent> Agent { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Organization>? Organization { get; set; }
        }
    }