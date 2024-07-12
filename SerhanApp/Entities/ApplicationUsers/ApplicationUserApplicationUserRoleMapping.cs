using SerhanApp.Core.Entities;

namespace SerhanApp.Data.Entities.ApplicationUsers
{
    public class ApplicationUserApplicationUserRoleMapping : BaseEntity
    {
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int ApplicationUserRoleId { get; set; }
        public ApplicationUserRole ApplicationUserRole { get; set; }
    }
}
