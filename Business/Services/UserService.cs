using EN.Business.Context;
using EN.Core.Declarations.Services;
using EN.Core.Entity;
using System.Linq;

namespace EN.Business.Services
{
    public class UserService : GenericRepository<User>, IUserService
    {
        EnContext enContext;
        public UserService(EnContext dbContext) : base(dbContext)
        {
            enContext = dbContext;
        }

        public User Login(User user)
        {
            var email = user.Email.ToLower().Trim();
            return enContext.Users.FirstOrDefault(x => x.Email == email
            && x.Password == user.Password);
        }
    }
}
