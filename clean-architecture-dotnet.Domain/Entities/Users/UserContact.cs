using clean_architecture_dotnet.Domain.Entities.Base;

namespace clean_architecture_dotnet.Domain.Entities.Users
{
    public class UserContact : EntityBase
    {
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; } = new User();
    }
} 