using clean_architecture_dotnet.Domain.Entities.Base;

namespace clean_architecture_dotnet.Domain.Entities.Products
{
    public class Product : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public virtual ProductType Type { get; set; } = new ProductType();
    }
}
