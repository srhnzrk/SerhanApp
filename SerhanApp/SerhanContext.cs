using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SerhanApp.Data.Entities.ApplicationUsers;

namespace SerhanApp.Data
{
    public class SerhanContext : DbContext
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationUserPassword> ApplicationUserPassword { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
        public DbSet<ApplicationUserApplicationUserRoleMapping> ApplicationUserApplicationUserRoleMapping { get; set; }


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
