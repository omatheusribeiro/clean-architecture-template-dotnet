using clean_architecture_dotnet.Domain.Entities.Base;
using clean_architecture_dotnet.Domain.Entities.Products;
using clean_architecture_dotnet.Domain.Entities.Users;

namespace clean_architecture_dotnet.Domain.Entities.Sales
{
    public class Sale : EntityBase
    {
        public decimal TotalValue { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = new Product();
        public virtual User User { get; set; } = new User();
    }
}
