using Microsoft.AspNetCore.Mvc;
using Moq;
using UserAPI.Controllers;
using UserAPI.Interfaces;
using UserAPI.Models;

namespace UserAPI.Test
{
    public class UserDetailsTests
    {
        //private readonly IUserDetailsRepository _userDetailsRepository;

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
    }
}