using SerhanApp.Data;
using SerhanApp.Data.Entities.ApplicationUsers;
using SerhanApp.Data.Entities.Security;
using System.Security;

namespace SerhanApp.Services.Security
{

    public class PermissionService : IPermissionService
    {
        #region Fields

        private readonly IGenericRepository<Permission> _permissionRepository;
        private readonly IGenericRepository<ApplicationUserRolePermissionMapping> _applicationUserRolePermissionMappingRepository;

        #endregion

        #region Ctor

        public PermissionService(
            IGenericRepository<Permission> permissionRepository,
            IGenericRepository<ApplicationUserRolePermissionMapping> applicationUserRolePermissionMappingRepository
            )
        {
            _permissionRepository = permissionRepository;
            _applicationUserRolePermissionMappingRepository = applicationUserRolePermissionMappingRepository;
        }

        #endregion

        #region Methods

        public List<Permission> GetPermissions()
        {
            return _permissionRepository.Table.ToList();
        }

        public List<Permission> GetPermissionsByApplicationUserRoleId(int roleId)
        {
            return _applicationUserRolePermissionMappingRepository.Table
                .Where(x => x.ApplicationUserRoleId == roleId)
                .Select(x => x.Permission)
                .ToList();
        }

        public Permission GetPermissionBySystemName(string systemName)
        {
            return _permissionRepository.Table.FirstOrDefault(x => x.SystemName == systemName);
        }

        public void InsertPermission(Permission permission)
        {
            _permissionRepository.InsertEntity(permission);
        }

        public void UpdatePermission(Permission permission)
        {
            _permissionRepository.UpdateEntity(permission);
        }

        public void DeletePermission(Permission permission)
        {
            _permissionRepository.RemoveEntity(permission);
        }

        #endregion




    }


}
