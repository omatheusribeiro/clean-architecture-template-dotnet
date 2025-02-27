using clean_architecture_dotnet.Domain.Entities.Products;
using clean_architecture_dotnet.Infrastructure.Context;
using clean_architecture_dotnet.Infrastructure.Repositories.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clean_architecture_dotnet.Infrastructure.Repositories.Products
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private ApplicationDbContext _context;

        public ProductTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductType>> GetAll()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<ProductType> GetById(int id)
        {
            return await _context.ProductTypes.AsNoTracking().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProductType> Put(ProductType productType)
        {
            productType.ChangeDate = DateTime.UtcNow;

            _context.ProductTypes.Update(productType);
            await _context.SaveChangesAsync();

            return productType;
        }

        public async Task<ProductType> Post(ProductType productType)
        {
            productType.CreationDate = DateTime.UtcNow;

            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return productType;
        }

        public async Task<ProductType> Delete(ProductType productType)
        {
            _context.ProductTypes.Remove(productType);
            await _context.SaveChangesAsync();

            return productType;
        }
    }
}
