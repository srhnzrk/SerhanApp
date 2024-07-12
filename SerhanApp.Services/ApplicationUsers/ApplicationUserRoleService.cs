using SerhanApp.Data;
using SerhanApp.Data.Entities.ApplicationUsers;

namespace SerhanApp.Services.ApplicationUsers
{
    public class ApplicationUserRoleService : IApplicationUserRoleService
    {
        #region Fields

        private readonly IGenericRepository<ApplicationUserRole> _applicationUserRoleRepository;

        #endregion

        #region Ctor

        public ApplicationUserRoleService(
            IGenericRepository<ApplicationUserRole> applicationUserRoleRepository)
        {
            _applicationUserRoleRepository = applicationUserRoleRepository;
        }

        #endregion

        #region Methods

        public List<ApplicationUserRole> GetApplicationUserRoles()
        {
            return _applicationUserRoleRepository.Table.ToList();
        }

        public void InsertApplicationUserRole(ApplicationUserRole applicationUserRole)
        {
            _applicationUserRoleRepository.InsertEntity(applicationUserRole);
        }

        public void UpdateApplicationUserRole(ApplicationUserRole applicationUserRole)
        {
            _applicationUserRoleRepository.UpdateEntity(applicationUserRole);
        }   

        public void DeleteApplicationUserRole(ApplicationUserRole applicationUserRole)
        {
            _applicationUserRoleRepository.RemoveEntity(applicationUserRole);
        }

        #endregion
    }
}
