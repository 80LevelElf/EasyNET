using EN.Business.Context;
using EN.Core.Declarations.Services;
using EN.Core.DTO;
using EN.Core.Entity;
using System;
using System.Linq;
using System.Text;

namespace EN.Business.Services
{
    public class UserService : GenericRepository<User>, IUserService
    {
        EnContext enContext;
        public UserService(EnContext dbContext) : base(dbContext)
        {
            enContext = dbContext;
        }

        public User Login(UserDto userDto)
        {
            var email = userDto.Email.ToLower().Trim();
            var userData = enContext.Users.FirstOrDefault(x => x.Email == email);
            if (userData == null)
            {
                return null;
            }
            if (!VerifyPasswordHash(userDto.Password, userData.PasswordHash, userData.PasswordSalt))
                return null;
            return userData;
        }
        public User Create(UserDto userDto)
        {
            userDto.Email = userDto.Email.ToLower().Trim();
            if (enContext.Users.Any(x => x.Email == userDto.Email))
            {
                return null;
            }
            byte[] hash, salt;
            CreatePasswordHash(userDto.Password, out hash, out salt);
            User user = new User();
            user.PasswordSalt = salt;
            user.PasswordHash = hash;
            user.Email = userDto.Email;
            enContext.Add(user);
            enContext.SaveChanges();
            return user;
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
