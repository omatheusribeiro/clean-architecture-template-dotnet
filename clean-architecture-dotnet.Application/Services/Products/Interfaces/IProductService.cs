using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.ViewModels.Products;

namespace clean_architecture_dotnet.Application.Services.Products.Interfaces
{
    public interface IProductService
    {
        Task<Result<IEnumerable<ProductViewModel>>> GetAll();
        Task<Result<ProductViewModel>> GetById(int id);
        Task<Result<ProductViewModel>> Put(ProductViewModel product);
        Task<Result<ProductViewModel>> Post(ProductViewModel product);
        Task<Result<ProductViewModel>> Delete(ProductViewModel product);
    }
}
