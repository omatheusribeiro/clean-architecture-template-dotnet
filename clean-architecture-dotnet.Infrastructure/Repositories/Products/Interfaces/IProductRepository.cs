using clean_architecture_dotnet.Domain.Entities.Products;

namespace clean_architecture_dotnet.Infrastructure.Repositories.Products.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Put(Product product);
        Task<Product> Post(Product product);
        Task<Product> Delete(Product product);
    }
}
