using Microsoft.EntityFrameworkCore;
using SerhanApp.Data.Entities.ApplicationUsers;
using SerhanApp.Data.Entities.Security;

namespace SerhanApp.Data
{
    public class SerhanContext : DbContext
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationUserPassword> ApplicationUserPassword { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
        public DbSet<ApplicationUserApplicationUserRoleMapping> ApplicationUserApplicationUserRoleMapping { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<ApplicationUserRolePermissionMapping> ApplicationUserRolePermissionMapping { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=JASON\SQLEXPRESS;Database=SerhanAppDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserPassword>().Ignore(x => x.PasswordType);
            modelBuilder.Entity<ApplicationUser>().Ignore(x => x.ApplicationUserRoles);

        }

    }
}
