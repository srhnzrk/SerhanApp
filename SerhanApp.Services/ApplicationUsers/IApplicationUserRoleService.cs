using SerhanApp.Data.Entities.ApplicationUsers;

namespace SerhanApp.Services.ApplicationUsers
{
    public interface IApplicationUserRoleService
    {
        void InsertApplicationUserRole(ApplicationUserRole applicationUserRole);
        void UpdateApplicationUserRole(ApplicationUserRole applicationUserRole);
        void DeleteApplicationUserRole(ApplicationUserRole applicationUserRole);
        List<ApplicationUserRole> GetApplicationUserRoles();
    }
}