using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models.Core;

namespace ProjectManagement.Models
{
    public class ProjectContext:IdentityDbContext<IdentityUser>
    {

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Project> Projects { get; set; }

        //public virtual DbSet<ProjectPhase> ProjectPhases { get; set; }
       
        public virtual DbSet<ProjectType> ProjectTypes { get; set; }
       
        //public virtual DbSet<ProjectPhaseType> ProjectPhaseTypes { get; set; }


    }
}
