//using Moq;
//using SerhanApp.Core.Entities;
//using SerhanApp.Data;
//using SerhanApp.Data.Entities.ApplicationUsers;
//using SerhanApp.Data.Entities.Catalog;
//using SerhanApp.Services.ApplicationUsers;
//using Xunit;

//namespace SerhanApp.Tests
//{
//    public class UnitTestMoq
//    {
//        [Fact]
//        public void Test2()
//        {
//            #region Arrange
//            var mockProductRepository = new Mock<IGenericRepository<Product>>();
//            var mockApplicationUserService = new Mock<ApplicationUserService>();
//            var product = new Product
//            {
//                Id = 1,
//                Name = "Test Product 2",
//                Description = "Test Description 2",
//                Price = 100,
//                VendorId = 2
//            };
//            var productToUpdate = new Product
//            {
//                Id = 13,
//                Name = "iphone 16",
//                Description = "new description",
//                Price = 65000,
//                VendorId = 2
//            };


//            var newUser = new ApplicationUser
//            {
//                Id = 1,
//                Name = "Serhan",
//                Surname = "Üzrek",
//                Email = "suzrek@outlook.com",
//                Active = true,
//            };

//            newUser.ApplicationUserPasswords.Add(new() { Password = "123456" });

            


//            mockProductRepository.Setup(x => x.InsertEntity(It.IsAny<Product>())).Callback<Product>(p => p.Id = product.Id);
//            mockProductRepository.Setup(x => x.GetEntityById(product.Id)).Returns(product);
//            mockProductRepository.Setup(x => x.GetEntityById(productToUpdate.Id)).Returns(productToUpdate);
//            #endregion
            
//            #region Act
//            mockProductRepository.Object.InsertEntity(product);
//            var retrievedProduct = mockProductRepository.Object.GetEntityById(product.Id);

//            mockProductRepository.Object.UpdateEntity(productToUpdate);

//            var updatedProduct = mockProductRepository.Object.GetEntityById(productToUpdate.Id);
//            #endregion

//            #region Assert
//            Assert.NotNull(retrievedProduct);
//            Assert.Equal(product.Name, retrievedProduct.Name);

//            Assert.NotNull(updatedProduct);
//            Assert.Equal("iphone 16", updatedProduct.Name);
//            #endregion
//        }
//    }
//}
