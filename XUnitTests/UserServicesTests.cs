using EN.Core.Declarations.Services;
using EN.Core.DTO;
using Xunit;

namespace XUnitTests
{
    public class UserServicesTests
    {
        [Fact]
        public void LoginTest()
        {
            IUserService userService = new MockUserService();
            Assert.NotNull(userService.Login(new UserDto { Email = "user@user.com", Password = "test" }));
        }
    }
}
