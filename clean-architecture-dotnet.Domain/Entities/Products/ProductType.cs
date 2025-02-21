using clean_architecture_dotnet.Domain.Entities.Base;

namespace clean_architecture_dotnet.Domain.Entities.Products
{
    public class ProductType : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
