using SerhanApp.Data.Entities.ApplicationUsers;
using SerhanApp.Data.Entities.Settings;
using SerhanApp.Data;
using SerhanApp.Services.Security;
using SerhanApp.Services.ApplicationUsers;

namespace SerhanApp.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IApplicationUserService _applicationUserService;

        private readonly CustomerSettings _customerSettings;
        private readonly AuthenticationSettings _authenticationSettings;



        #endregion

        #region Ctor

        public AuthenticationService(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;

            _customerSettings = new CustomerSettings();
            _authenticationSettings = new AuthenticationSettings();
        }

        #endregion

        #region Methods

        #region Login

        public LoginResult LoginRequest(string emailOrUsername, string password)
        {
            ApplicationUser? applicationUser = null;
            var result = LoginResult.Success;

            if (_customerSettings.EnableUsername)
                applicationUser = _applicationUserService.GetApplicationUserByUsername(emailOrUsername);
            else
                applicationUser = _applicationUserService.GetApplicationUserByEmail(emailOrUsername);

            if (applicationUser == null)
                return LoginResult.ApplicationUserNotFound;

            if (applicationUser.Deleted || applicationUser.Active)
                return LoginResult.Failed;

            if (applicationUser.CannotLoginUntilDateUtc > DateTime.UtcNow)
                return LoginResult.CannotLoginUntilDate;

            if (_customerSettings.RequireEmailVerification && !applicationUser.IsEmailVerified)
                return LoginResult.RequireEmailVerification;

            var passwordValidationSuccess = _applicationUserService.ValidateApplicationUserPasword(password);
            if (!passwordValidationSuccess)
            {
                result = LoginResult.WrongPassword;
            }

            if (result == LoginResult.Success)
            {
                applicationUser.LastLoginDateUtc = DateTime.UtcNow;
            }
            else
            {
                applicationUser.FailedLoginAttempts += 1;

                if (applicationUser.FailedLoginAttempts >= _authenticationSettings.FailedLoginAttemptMaximumTryCount)
                    applicationUser.CannotLoginUntilDateUtc = DateTime.UtcNow.AddMinutes(_authenticationSettings.CannotLoginUntilTimeAsMinute);

                _applicationUserService.UpdateApplicationUser(applicationUser);
            }

            return result;
        }

        #endregion

        #region Register

        public RegisterResult RegisterRequest(string emailOrUsername, string password, string name, string surname)
        {
            var result = RegisterResult.Success;

            ApplicationUser? applicationUser = null;

            if (_customerSettings.EnableUsername)
                applicationUser = _applicationUserService.GetApplicationUserByUsername(emailOrUsername);
            else
                applicationUser = _applicationUserService.GetApplicationUserByEmail(emailOrUsername);

            if (applicationUser != null)
                return RegisterResult.AlreadyRegisteredApplicationUser;

            applicationUser = new ApplicationUser
            {
                Email = _customerSettings.EnableUsername ? string.Empty : emailOrUsername,
                Username = emailOrUsername,
                Name = name,
                Surname = surname,
                Active = !_customerSettings.RequireEmailVerification,
                IsEmailVerified = false,
                CreatedOnUtc = DateTime.UtcNow,
                FailedLoginAttempts = 0,
                Deleted = false,
            };

            _applicationUserService.InsertApplicationUser(applicationUser);
            _applicationUserService.InsertApplicationUserPassword(password, applicationUser.Id);

            return result;
        }

        #endregion

        #endregion

    }
}