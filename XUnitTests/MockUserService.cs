using EN.Core.Declarations.Services;
using EN.Core.DTO;
using EN.Core.Entity;

namespace XUnitTests
{
    public class MockUserService : IUserService
    {
        public User Create(UserDto userDto)
        {
            throw new System.NotImplementedException();
        }

        public User Login(UserDto userDto)
        {
            if (userDto.Email == "user@user.com")
            {
                return new User { Email = "user@user.com" };
            }
            return null;
        }
    }
}
