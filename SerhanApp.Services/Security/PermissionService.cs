using SerhanApp.Data;
using SerhanApp.Data.Entities.ApplicationUsers;
using SerhanApp.Data.Entities.Security;
using System.Linq;
using System.Security;

namespace SerhanApp.Services.Security
{

    public class PermissionService : IPermissionService
    {
        #region Fields

        private readonly IGenericRepository<Permission> _permissionRepository;
        private readonly IGenericRepository<ApplicationUserRolePermissionMapping> _applicationUserRolePermissionMappingRepository;
        private readonly IGenericRepository<ApplicationUserApplicationUserRoleMapping> _applicationUserApplicationUserRoleMappingRepository;

        #endregion

        #region Ctor

        public PermissionService(
            IGenericRepository<Permission> permissionRepository,
            IGenericRepository<ApplicationUserRolePermissionMapping> applicationUserRolePermissionMappingRepository,
            IGenericRepository<ApplicationUserApplicationUserRoleMapping> applicationUserApplicationUserRoleMappingRepository
            )
        {
            _permissionRepository = permissionRepository;
            _applicationUserRolePermissionMappingRepository = applicationUserRolePermissionMappingRepository;
            _applicationUserApplicationUserRoleMappingRepository = applicationUserApplicationUserRoleMappingRepository;
        }

        #endregion

        #region Methods

        public List<Permission> GetPermissions()
        {
            return _permissionRepository.Table.ToList();
        }

        public List<Permission> GetPermissionsByApplicationUserRoleId(int applicationUserRoleId)
        {
            return _applicationUserRolePermissionMappingRepository.Table
                .Where(x => x.ApplicationUserRoleId == applicationUserRoleId)
                .Select(x => x.Permission)
                .ToList();
        }

        public List<Permission> GetPermissionsByApplicationUserId(int applicationUserId)
        {
            var query = from roleMapping in _applicationUserApplicationUserRoleMappingRepository.Table
                        join rolePermissionMapping in _applicationUserRolePermissionMappingRepository.Table on roleMapping.ApplicationUserRoleId equals rolePermissionMapping.ApplicationUserRoleId
                        join permission in _permissionRepository.Table on rolePermissionMapping.PermissionId equals permission.Id
                        where roleMapping.ApplicationUserId == applicationUserId
                        select permission;

            var permissions = query.ToList();

            return permissions;
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
