using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SerhanApp.Data;
using SerhanApp.Data.Entities.ApplicationUsers;
using SerhanApp.Data.Entities.Settings;
using System.Security.Cryptography;
using SerhanApp.Services.Security;
using System.Text;
using Microsoft.EntityFrameworkCore.Query;

namespace SerhanApp.Services.ApplicationUsers
{
    public class ApplicationUserService : IApplicationUserService
    {
        #region Fields

        private readonly IGenericRepository<ApplicationUser> _applicationUserRepository;
        private readonly IGenericRepository<ApplicationUserPassword> _applicationUserPasswordRepository;

        private readonly CustomerPasswordSettings _customerPasswordSettings;
        private readonly EncryptionService _encryptionService;

        #endregion

        #region Ctor

        public ApplicationUserService(
            IGenericRepository<ApplicationUser> applicationUserRepository,
            IGenericRepository<ApplicationUserPassword> applicationUserPasswordRepository
            )
        {
            _applicationUserRepository = applicationUserRepository;
            _applicationUserPasswordRepository = applicationUserPasswordRepository;

            _customerPasswordSettings = new CustomerPasswordSettings();
            _encryptionService = new EncryptionService();
        }

        #endregion

        #region Methods

        #region Application User

        public List<ApplicationUser> SearchApplicationUsers(string name = "", string surname = "",
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _applicationUserRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name == name);

            if (!string.IsNullOrEmpty(surname))
                query = query.Where(x => x.Surname == surname);

            query = query.Skip(pageIndex * pageSize).Take(pageSize);

            var applicationUsers = query.ToList();

            return applicationUsers;
        }

        public ApplicationUser GetApplicationUserById(int id)
        {
            return _applicationUserRepository.Table.FirstOrDefault(x => x.Id == id);
        }

        public ApplicationUser GetApplicationUserByEmail(string email)
        {
            return _applicationUserRepository.Table.FirstOrDefault(x => x.Email == email);
        }

        public ApplicationUser GetApplicationUserByUsername(string username)
        {
            return _applicationUserRepository.Table.FirstOrDefault(x => x.Username == username);
        }

        public void InsertApplicationUser(ApplicationUser applicationUser)
        {
            _applicationUserRepository.InsertEntity(applicationUser);
        }

        public void UpdateApplicationUser(ApplicationUser applicationUser)
        {
            _applicationUserRepository.UpdateEntity(applicationUser);
        }

        public void DeleteApplicationUser(ApplicationUser applicationUser)
        {
            _applicationUserRepository.RemoveEntity(applicationUser);
        }


        #endregion

        #region Application User Password

        public ApplicationUserPassword GetApplicationUserActivePassword(int applicationUserId)
        {
            return _applicationUserPasswordRepository.Table.OrderByDescending(x => x.Id).FirstOrDefault(x => x.ApplicationUserId == applicationUserId);
        }

        public List<ApplicationUserPassword> GetApplicationUserPasswords(ApplicationUser applicationUser)
        {
            return _applicationUserPasswordRepository.Table.Where(x => x.ApplicationUserId == applicationUser.Id).ToList();
        }

        public ApplicationUserPassword InsertApplicationUserPassword(string password, int applicationUserId, PasswordType passwordType = PasswordType.Hashed)
        {
            var applicationUserPassword = new ApplicationUserPassword
            {
                ApplicationUserId = applicationUserId,
                Password = (passwordType == PasswordType.Hashed ? _encryptionService.EncryptText(password) : password),
                PasswordTypeId = (int)passwordType
            };

            _applicationUserPasswordRepository.InsertEntity(applicationUserPassword);

            return applicationUserPassword;
        }

        public bool ValidateApplicationUserPasword(string password, ApplicationUser? applicationUser = null)
        {
            if (applicationUser != null)
            {
                var activePassword = GetApplicationUserActivePassword(applicationUser.Id);

                if (activePassword.PasswordType == PasswordType.Hashed)
                {
                    var encryptedPassword = _encryptionService.EncryptText(password);
                    if (activePassword.Password != encryptedPassword)
                        return false;
                }

                if (activePassword.PasswordType == PasswordType.Clear)
                {
                    if (activePassword.Password != password)
                        return false;
                }
            }

            if (password.Length < _customerPasswordSettings.MininumLength || password.Length > _customerPasswordSettings.MaximumLength)
                return false;

            if (_customerPasswordSettings.RequireUppercase && !password.Any(char.IsUpper))
                return false;

            if (_customerPasswordSettings.RequireLowercase && !password.Any(char.IsLower))
                return false;

            if (_customerPasswordSettings.RequireSpecialCharacter && !password.Any(char.IsSymbol))
                return false;

            if (_customerPasswordSettings.RequireDigit && !password.Any(char.IsDigit))
                return false;

            return true;
        }

        #endregion

        #endregion
    }
}
