using EN.Core.Declarations.Services;
using EN.Core.Entity;

namespace XUnitTests
{
    public class MockUserService : IUserService
    {
        public User Login(User user)
        {
            if (user.Email == "user@user.com")
            {
                return new User { Email = "user@user.com" };
            }
            return null;
        }
    }
}
