using SerhanApp.Core.Entities;
using SerhanApp.Data.Entities.ApplicationUsers;

namespace SerhanApp.Data.Entities.Security
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public string SystemName { get; set; }

        public virtual ICollection<ApplicationUserRolePermissionMapping> ApplicationUserRolePermissionMapping { get; set; }
    }
}
