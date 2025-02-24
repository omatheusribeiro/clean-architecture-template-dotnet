using AutoMapper;
using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.Services.Products.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Products;
using clean_architecture_dotnet.Domain.Entities.Products;
using clean_architecture_dotnet.Infrastructure.Repositories.Products.Interfaces;

namespace clean_architecture_dotnet.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ProductViewModel>>> GetAll()
        {
            try
            {
                var products = await _productRepository.GetAll();

                if (products is null)
                    return Result<IEnumerable<ProductViewModel>>.Fail("Unable to identify products in the database.", 404);

                var mapProducts = _mapper.Map<IEnumerable<ProductViewModel>>(products);

                return Result<IEnumerable<ProductViewModel>>.Ok(mapProducts);

            }
            catch (Exception ex)
            {
                return Result<IEnumerable<ProductViewModel>>.Fail("There was an error listing products: " + ex.Message, 500);
            }

        }

        public async Task<Result<ProductViewModel>> GetById(int id)
        {
            try
            {
                var product = await _productRepository.GetById(id);

                if (product is null)
                    return Result<ProductViewModel>.Fail("product not found.", 404);

                var mapProduct = _mapper.Map<ProductViewModel>(product);

                return Result<ProductViewModel>.Ok(mapProduct);
            }
            catch (Exception ex)
            {
                return Result<ProductViewModel>.Fail("There was an error when searching for the product: " + ex.Message, 500);
            }

        }

        public async Task<Result<ProductViewModel>> Put(ProductViewModel product)
        {
            try
            {
                var mapProduct = _mapper.Map<Product>(product);

                var result = await _productRepository.Put(mapProduct);

                var mapProductModel = _mapper.Map<ProductViewModel>(result);

                return Result<ProductViewModel>.Ok(mapProductModel);
            }
            catch (Exception ex)
            {
                return Result<ProductViewModel>.Fail("There was an error editing the product: " + ex.Message, 500);
            }
        }

        public async Task<Result<ProductViewModel>> Post(ProductViewModel product)
        {
            try
            {

                var mapProduct = _mapper.Map<Product>(product);

                var result = await _productRepository.Post(mapProduct);

                var mapProductModel = _mapper.Map<ProductViewModel>(result);

                return Result<ProductViewModel>.Ok(mapProductModel);
            }
            catch (Exception ex)
            {
                return Result<ProductViewModel>.Fail("There was an error registering the product: " + ex.Message, 500);
            }
        }

        public async Task<Result<ProductViewModel>> Delete(ProductViewModel product)
        {
            try
            {

                var mapProduct = _mapper.Map<Product>(product);

                var result = await _productRepository.Delete(mapProduct);

                var mapProductModel = _mapper.Map<ProductViewModel>(result);

                return Result<ProductViewModel>.Ok(mapProductModel);
            }
            catch (Exception ex)
            {
                return Result<ProductViewModel>.Fail("There was an error deleting the product: " + ex.Message, 500);
            }

        }
    }
}
