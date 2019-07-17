
namespace EN.Core.Entity
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
