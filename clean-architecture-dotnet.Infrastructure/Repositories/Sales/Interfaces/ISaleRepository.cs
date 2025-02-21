using clean_architecture_dotnet.Domain.Entities.Sales;

namespace clean_architecture_dotnet.Infrastructure.Repositories.Sales.Interfaces
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAll();
        Task<Sale> GetById(int id);
        Task<Sale> Put(Sale sale);
        Task<Sale> Post(Sale sale);
        Task<Sale> Delete(Sale sale);
    }
}
