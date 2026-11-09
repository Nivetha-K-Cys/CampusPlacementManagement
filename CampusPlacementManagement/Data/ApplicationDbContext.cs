using CampusPlacementManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CampusPlacementManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }

        public DbSet<JobApplication> JobApplications { get; set; }

        public DbSet<College> Colleges { get; set; }
        public DbSet<PlacementOfficer> PlacementOfficers { get; set; }
    }
}