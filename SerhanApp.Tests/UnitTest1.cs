//using Moq;
//using SerhanApp.Core.Entities;
//using SerhanApp.Data;
//using SerhanApp.Data.Entities.ApplicationUsers;
//using SerhanApp.Data.Entities.Catalog;
//using SerhanApp.Services.ApplicationUsers;
//using Xunit;

//namespace SerhanApp.Tests
//{
//    public class UnitTest1
//    {
//        [Fact]
//        public void Test1()
//        {
//            #region Arrange

//            var mockApplicationUserRepository = new Mock<IGenericRepository<ApplicationUser>>();
//            var mockApplicationUserPasswordRepository = new Mock<IGenericRepository<ApplicationUserPassword>>();

//            var newUser = new ApplicationUser
//            {
//                Id = 1,
//                Name = "Serhan",
//                Surname = "Üzrek",
//                Email = "suzrek@outlook.com",
//                Active = true,
//            };

//            newUser.ApplicationUserPasswords.Add(new() { Password = "123456" });

//            #endregion


//            #region Act

//            mockApplicationUserRepository.Object.InsertApplicationUser(newUser);
//            var userPassword = mockApplicationUserRepository.Object.GetApplicationUserActivePassword(newUser);

//            #endregion


//            #region Assert

//            Assert.Equal("123456", userPassword.Password);

//            #endregion
//        }
//    }
//}
