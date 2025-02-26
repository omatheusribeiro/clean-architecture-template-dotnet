using clean_architecture_dotnet.Domain.Entities.Base;
using clean_architecture_dotnet.Domain.Entities.Sales;

namespace clean_architecture_dotnet.Domain.Entities.Users
{
    public class UserContact : EntityBase
    {
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int UserId { get; set; }
        public virtual ICollection<User> User { get; set; }

        public UserContact()
        {
            User = new HashSet<User>();
        }
    }
} 