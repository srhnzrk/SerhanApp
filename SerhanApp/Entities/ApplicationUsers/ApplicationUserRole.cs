using SerhanApp.Core.Entities;

namespace SerhanApp.Data.Entities.ApplicationUsers
{
    public class ApplicationUserRole : BaseEntity
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<ApplicationUserApplicationUserRoleMapping> ApplicationUserApplicationUserRoleMapping { get; set; }
        public virtual ICollection<ApplicationUserRolePermissionMapping> ApplicationUserRolePermissionMapping { get; set; }
    }
}
