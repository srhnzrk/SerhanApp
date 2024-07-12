//using SerhanApp.Core.Entities;
//using SerhanApp.Data;
//using SerhanApp.Data.Entities.ApplicationUsers;
//using SerhanApp.Data.Entities.Catalog;
//using SerhanApp.Services.ApplicationUsers;
//using Xunit;

//namespace SerhanApp.Tests
//{

//    public class Class1
//    {
//        [Fact]
//        public void ClassTest1()
//        {
//            var context = new SerhanContext();

//            var userRepository = new GenericRepository<ApplicationUser>(context);
//            var passwordRepository = new GenericRepository<ApplicationUserPassword>(context);
//            var loginRepository = new GenericRepository<LoginResult>(context);

//            var userService = new ApplicationUserService(userRepository, passwordRepository);
//            var loginService = new LoginService(loginRepository, userService);

//            //var newUser = new ApplicationUser
//            //{
//            //    Name = "Ahmet",
//            //    Surname = "Öküz",
//            //    Email = "aokuz@outlook.com",
//            //    Active = true
//            //};

//            var newUser = userRepository.Table.FirstOrDefault(x => x.Id == 1);

//            userService.CreateApplicationUserPassword("As_43215-Asadf", newUser);

//            var checkPassword = userService.ValidateApplicationUserPassword("As_43215-Asadf");

//            if (checkPassword == null)
//            {
//                throw new UnauthorizedAccessException("password is not correct");
//            }
//        }
//    }
//}
