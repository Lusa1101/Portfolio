using Microsoft.EntityFrameworkCore;
using Porfolio.Models;

namespace Porfolio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<ProjectImage> ProjectImages => Set<ProjectImage>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Qualification> Qualifications => Set<Qualification>();
        public DbSet<Reference> References => Set<Reference>();
        public DbSet<Experience> Experiences => Set<Experience>();
        public DbSet<Blog> Blogs => Set<Blog>();


        
    }
}
