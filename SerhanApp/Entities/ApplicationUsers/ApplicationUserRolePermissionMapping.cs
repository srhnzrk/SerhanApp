using SerhanApp.Core.Entities;
using SerhanApp.Data.Entities.Security;

namespace SerhanApp.Data.Entities.ApplicationUsers
{
    public class ApplicationUserRolePermissionMapping : BaseEntity
    {
        public int ApplicationUserRoleId { get; set; }
        public ApplicationUserRole ApplicationUserRole { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
