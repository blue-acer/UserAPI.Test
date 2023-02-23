using Microsoft.AspNetCore.Mvc;
using Moq;
using UserAPI.Controllers;
using UserAPI.Interfaces;
using UserAPI.Models;

namespace UserAPI.Test
{
    public class UserDetailsTests
    {
        
        [Fact]
        public async Task UserDetailsController_GetAllUserDetails_ReturnOKAsync()
        {
            //Arrange
            var mockInterface = new Mock<IUserDetailsRepository>();

            var user1 = new UserDetails();
            user1.FirstName = "Jane";
            user1.LastName = "Doe";
            user1.EmailAddress = "jane.doe@test.com";
            
            var user2 = new UserDetails();
            user2.FirstName = "John";
            user2.LastName = "Smith";
            user2.EmailAddress = "j.smith@test.com";

            mockInterface.Setup(x =>
            x.GetAllUserDetailsData()).ReturnsAsync(
                new List<UserDetails>
                {
                user1,
                user2
                });

            var controller = new UserDetailsController(mockInterface.Object);

            //Act
            var usersResult = await controller.GetAllUserDetails();

            //Assert
            var result = usersResult.Result as OkObjectResult;
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UserDetailsController_GetAllUsersSP_ReturnOKAsync()
        {
            //Arrange
            var mockInterface = new Mock<IUserDetailsRepository>();

            var user1 = new UserDetails();
            user1.FirstName = "Jane";
            user1.LastName = "Doe";
            user1.EmailAddress = "jane.doe@test.com";
            
            var user2 = new UserDetails();
            user2.FirstName = "John";
            user2.LastName = "Smith";
            user2.EmailAddress = "j.smith@test.com";

            mockInterface.Setup(x =>
            x.GetAllUserDetailsSPData()).ReturnsAsync(
                new List<UserDetails>
                {
                user1,
                user2
                });

            var controller = new UserDetailsController(mockInterface.Object);

            //Act
            var usersResult = await controller.GetAllUserDetailsSP();

            //Assert
            var result = usersResult.Result as OkObjectResult;
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UserDetailsController_GetUserDetails_ReturnOk()
        {
            //Arrange
            var mockInterface = new Mock<IUserDetailsRepository>();

            var user1 = new UserDetails();
            user1.FirstName = "Jane";
            user1.LastName = "Doe";
            user1.EmailAddress = "jane.doe@test.com";
            user1.UserId = 1;

            mockInterface.Setup(x =>
           x.GetUserDetailsData(1)).ReturnsAsync(user1);

            var controller = new UserDetailsController(mockInterface.Object);

            //Act
            var userResult = await controller.GetUserDetails(1);

            //Assert
            var result = userResult.Result as OkObjectResult;
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UserDetailsController_GetUserDetailsByEmail_ReturnOK()
        {
            //Arrange
            var mockInterface = new Mock<IUserDetailsRepository>();

            var user1 = new UserDetails();
            user1.FirstName = "Jane";
            user1.LastName = "Doe";
            user1.EmailAddress = "jane.doe@test.com";
            
            mockInterface.Setup(x =>
            x.GetUserDetailsDataByEmail(user1.EmailAddress)).ReturnsAsync(
                new List<UserDetails>
                {
                user1
                });

            var controller = new UserDetailsController(mockInterface.Object);

            //Act
            var usersResult = await controller.GetUserDetailsByEmail(user1.EmailAddress);

            //Assert
            var result = usersResult.Result as OkObjectResult;
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UserDetailsController_DeleteUser_ReturnOK()
        {
            //Arrange
            var mockInterface = new Mock<IUserDetailsRepository>();

            var userId = 1;

            mockInterface.Setup(x =>
            x.deleteUserData(userId)).ReturnsAsync(1);

            var controller = new UserDetailsController(mockInterface.Object);

            //Act
            var usersResult = await controller.DeleteUser(userId);

            //Assert
            var result = usersResult.Result as OkObjectResult;
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UserDetailsController_AddUser_ReturnOK()
        {
            //Arrange
            var mockInterface = new Mock<IUserDetailsRepository>();
            
            var fName = "Jane";
            var lName = "Doe";
            var email = "jane.doe@test.com";

            mockInterface.Setup(x => 
            x.addUserData(fName,lName, email)).ReturnsAsync(1);

            var controller = new UserDetailsController(mockInterface.Object);

            //Act
            var userResult = await controller.AddUser(fName, lName, email);

            //Assert
            var result = userResult.Result as OkObjectResult;
            Assert.NotNull(result);
        }
    }
}