using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using UserAPI.Entities;
using UserAPI.Interfaces;
using UserAPI.Models;

namespace UserAPI.Test
{
    public class UserDetailsTests
    {
        private readonly IUserDetailsRepository _userDetailsRepository;

        public UserDetailsTests()
        {
            _userDetailsRepository = A.Fake<IUserDetailsRepository>();
        }

        [Fact]
        public void Test1()
        {
            

        }
    }
}