using clean_architecture_dotnet.Domain.Entities.Base;
using clean_architecture_dotnet.Domain.Entities.Sales;

namespace clean_architecture_dotnet.Domain.Entities.Users
{
    public class User : EntityBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public virtual UserAddress Address { get; set; }
        public virtual UserContact Contact { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }

        public User()
        {
            Sale = new HashSet<Sale>();
        }
    }
}
