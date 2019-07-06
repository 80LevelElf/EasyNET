using EN.Core.Declarations.Services;
using EN.Core.Entity;
using Xunit;

namespace XUnitTests
{
    public class UserServicesTests
    {
        [Fact]
        public void LoginTest()
        {
            IUserService userService = new MockUserService();
            Assert.NotNull(userService.Login(new User { Email = "user@user.com" }));
        }
    }
}
