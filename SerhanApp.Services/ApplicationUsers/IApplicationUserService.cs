using SerhanApp.Data.Entities.ApplicationUsers;
using SerhanApp.Data.Entities.Settings;
using SerhanApp.Services.Security;

namespace SerhanApp.Services.ApplicationUsers
{
    public interface IApplicationUserService
    {

        #region Application User

        List<ApplicationUser> SearchApplicationUsers(string name = "", string surname = "",
            int pageIndex = 0, int pageSize = int.MaxValue);
        List<ApplicationUser> GetApplicationUsers();
        ApplicationUser GetApplicationUserById(int id);
        ApplicationUser GetApplicationUserByEmail(string email);
        ApplicationUser GetApplicationUserByUsername(string username);
        void InsertApplicationUser(ApplicationUser applicationUser);
        void UpdateApplicationUser(ApplicationUser applicationUser);
        void DeleteApplicationUser(ApplicationUser applicationUser);

        #endregion

        #region Application User Password

        ApplicationUserPassword GetApplicationUserActivePassword(int applicationUserId);
        List<ApplicationUserPassword> GetApplicationUserPasswords(ApplicationUser applicationUser);
        ApplicationUserPassword InsertApplicationUserPassword(string password, int applicationUserId, PasswordType passwordType = PasswordType.Hashed);
        bool ValidateApplicationUserPasword(string password, ApplicationUser? applicationUser = null);

        #endregion

    }
}
