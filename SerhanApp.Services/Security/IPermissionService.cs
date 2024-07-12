using SerhanApp.Data.Entities.Security;

namespace SerhanApp.Services.Security
{
    public interface IPermissionService
    {
        List<Permission> GetPermissions();
        void InsertPermission(Permission permission);
        void UpdatePermission(Permission permission);
        public void DeletePermission(Permission permission);
    }
}