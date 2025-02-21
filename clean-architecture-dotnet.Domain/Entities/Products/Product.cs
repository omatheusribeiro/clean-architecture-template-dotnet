using clean_architecture_dotnet.Domain.Entities.Base;
using clean_architecture_dotnet.Domain.Entities.Sales;

namespace clean_architecture_dotnet.Domain.Entities.Products
{
    public class Product : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType Type { get; set; } = new ProductType();
        public ICollection<Sale> Sale { get; set; } = new List<Sale>();
    }
}
