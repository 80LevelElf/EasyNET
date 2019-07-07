using EN.Core.DTO;
using EN.Core.Entity;

namespace EN.Core.Declarations.Services
{
    public interface IUserService
    {
        User Login(UserDto userDto);
        User Create(UserDto userDto);
    }
}
