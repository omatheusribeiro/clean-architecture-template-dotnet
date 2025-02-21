using clean_architecture_dotnet.Domain.Entities.Base;
using clean_architecture_dotnet.Domain.Entities.Sales;

namespace clean_architecture_dotnet.Domain.Entities.Users
{
    public class User : EntityBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public ICollection<UserAddress> Address { get; set; } = new List<UserAddress>();
        public ICollection<UserContact> Contact { get; set; } = new List<UserContact>();
        public ICollection<Sale> Sale { get; set; } = new List<Sale>();
    }
}
