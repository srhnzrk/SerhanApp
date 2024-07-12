using SerhanApp.Core.Entities;

namespace SerhanApp.Data.Entities.ApplicationUsers
{
    public class ApplicationUser : BaseEntity, ISoftDeletedEntity
    {
        public ApplicationUser()
        {
            ApplicationUserPasswords = new List<ApplicationUserPassword>();
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public bool RequireReLogin { get; set; }

        public int FailedLoginAttempts { get; set; }

        public DateTime? CannotLoginUntilDateUtc { get; set; }

        public DateTime? LastLoginDateUtc { get; set; }

        public DateTime? LastActivityDateUtc { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public bool IsEmailVerified { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public int? UpdatedByApplicationUserId { get; set; }

        public DateTime? DeletedOnUtc { get; set; }

        public virtual ICollection<ApplicationUserPassword> ApplicationUserPasswords { get; set; }

        public virtual ICollection<ApplicationUserApplicationUserRoleMapping> ApplicationUserApplicationUserRoleMapping { get; set; }

        public virtual List<ApplicationUserRole> ApplicationUserRoles
        {
            get
            {
                return this.ApplicationUserApplicationUserRoleMapping.Select(x => x.ApplicationUserRole).ToList();
            }
        }
    }
}
