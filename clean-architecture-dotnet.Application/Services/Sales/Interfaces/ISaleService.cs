using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.ViewModels.Sales;

namespace clean_architecture_dotnet.Application.Services.Sales.Interfaces
{
    public interface ISaleService
    {
        Task<Result<IEnumerable<SaleViewModel>>> GetAll();
        Task<Result<SaleViewModel>> GetById(int id);
        Task<Result<SaleViewModel>> Put(SaleViewModel sale);
        Task<Result<SaleViewModel>> Post(SaleViewModel sale);
        Task<Result<SaleViewModel>> Delete(SaleViewModel sale);
    }
}
