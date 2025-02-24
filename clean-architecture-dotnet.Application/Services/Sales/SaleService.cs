using AutoMapper;
using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.Services.Sales.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Sales;
using clean_architecture_dotnet.Domain.Entities.Sales;
using clean_architecture_dotnet.Infrastructure.Repositories.Sales.Interfaces;

namespace clean_architecture_dotnet.Application.Services.Sales
{
    public class SaleService : ISaleService
    {
        private ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public SaleService(IMapper mapper, ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<SaleViewModel>>> GetAll()
        {
            try
            {
                var sales = await _saleRepository.GetAll();

                if (sales is null)
                    return Result<IEnumerable<SaleViewModel>>.Fail("Unable to identify sales in the database.", 404);

                var mapSales = _mapper.Map<IEnumerable<SaleViewModel>>(sales);

                return Result<IEnumerable<SaleViewModel>>.Ok(mapSales);

            }
            catch (Exception ex)
            {
                return Result<IEnumerable<SaleViewModel>>.Fail("There was an error listing sales: " + ex.Message, 500);
            }

        }

        public async Task<Result<SaleViewModel>> GetById(int id)
        {
            try
            {
                var sale = await _saleRepository.GetById(id);

                if (sale is null)
                    return Result<SaleViewModel>.Fail("sale not found.", 404);

                var mapSale = _mapper.Map<SaleViewModel>(sale);

                return Result<SaleViewModel>.Ok(mapSale);
            }
            catch (Exception ex)
            {
                return Result<SaleViewModel>.Fail("There was an error when searching for the sale: " + ex.Message, 500);
            }
        }

        public async Task<Result<SaleViewModel>> Put(SaleViewModel sale)
        {
            try
            {
                var mapSale = _mapper.Map<Sale>(sale);

                var result = await _saleRepository.Put(mapSale);

                var mapSaleModel = _mapper.Map<SaleViewModel>(result);

                return Result<SaleViewModel>.Ok(mapSaleModel);
            }
            catch (Exception ex)
            {
                return Result<SaleViewModel>.Fail("There was an error editing the sale: " + ex.Message, 500);
            }
        }

        public async Task<Result<SaleViewModel>> Post(SaleViewModel sale)
        {
            try
            {

                var mapSale = _mapper.Map<Sale>(sale);

                var result = await _saleRepository.Post(mapSale);

                var mapSaleModel = _mapper.Map<SaleViewModel>(result);

                return Result<SaleViewModel>.Ok(mapSaleModel);
            }
            catch (Exception ex)
            {
                return Result<SaleViewModel>.Fail("There was an error registering the sale: " + ex.Message, 500);
            }
        }

        public async Task<Result<SaleViewModel>> Delete(SaleViewModel sale)
        {
            try
            {

                var mapSale = _mapper.Map<Sale>(sale);

                var result = await _saleRepository.Delete(mapSale);

                var mapSaleModel = _mapper.Map<SaleViewModel>(result);

                return Result<SaleViewModel>.Ok(mapSaleModel);
            }
            catch (Exception ex)
            {
                return Result<SaleViewModel>.Fail("There was an error deleting the sale: " + ex.Message, 500);
            }

        }
    }
}
