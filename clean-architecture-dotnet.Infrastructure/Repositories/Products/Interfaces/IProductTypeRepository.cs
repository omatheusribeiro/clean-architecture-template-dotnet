using clean_architecture_dotnet.Domain.Entities.Products;

namespace clean_architecture_dotnet.Infrastructure.Repositories.Products.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetAll();
        Task<ProductType> GetById(int id);
        Task<ProductType> Put(ProductType product);
        Task<ProductType> Post(ProductType product);
        Task<ProductType> Delete(ProductType product);
    }
}
