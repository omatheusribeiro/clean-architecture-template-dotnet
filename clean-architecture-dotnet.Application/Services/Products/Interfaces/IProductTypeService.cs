using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.ViewModels.Products;

namespace clean_architecture_dotnet.Application.Services.Products.Interfaces
{
    public interface IProductTypeService
    {
        Task<Result<ProductTypeViewModel>> Put(ProductTypeViewModel product);
        Task<Result<ProductTypeViewModel>> Post(ProductTypeViewModel product);
    }
}
