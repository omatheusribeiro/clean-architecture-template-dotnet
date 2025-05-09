﻿using AutoMapper;
using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.Services.Products.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Products;
using clean_architecture_dotnet.Domain.Entities.Products;
using clean_architecture_dotnet.Domain.Enums;
using clean_architecture_dotnet.Infrastructure.Repositories.Products.Interfaces;

namespace clean_architecture_dotnet.Application.Services.Products
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductTypeService(IMapper mapper, IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ProductTypeViewModel>>> GetAll()
        {
            try
            {
                var products = await _productTypeRepository.GetAll();

                if (products is null)
                    return Result<IEnumerable<ProductTypeViewModel>>.Fail("Unable to identify product types in the database.", (int)HttpStatus.BadRequest);

                var mapProducts = _mapper.Map<IEnumerable<ProductTypeViewModel>>(products);

                return Result<IEnumerable<ProductTypeViewModel>>.Ok(mapProducts);

            }
            catch (Exception ex)
            {
                return Result<IEnumerable<ProductTypeViewModel>>.Fail("There was an error listing product types: " + ex.Message);
            }

        }

        public async Task<Result<ProductTypeViewModel>> GetById(int id)
        {
            try
            {
                var product = await _productTypeRepository.GetById(id);

                if (product is null)
                    return Result<ProductTypeViewModel>.Fail("product type not found.", (int)HttpStatus.BadRequest);

                var mapProduct = _mapper.Map<ProductTypeViewModel>(product);

                return Result<ProductTypeViewModel>.Ok(mapProduct);
            }
            catch (Exception ex)
            {
                return Result<ProductTypeViewModel>.Fail("There was an error when searching for the product type: " + ex.Message);
            }

        }

        public async Task<Result<ProductTypeViewModel>> Put(ProductTypeViewModel productType)
        {
            try
            {
                var type = await _productTypeRepository.GetById(productType.Id);

                if (type is null)
                    return Result<ProductTypeViewModel>.Fail("product type not found.", (int)HttpStatus.BadRequest);

                var mapProductType = _mapper.Map<ProductType>(productType);

                var result = await _productTypeRepository.Put(mapProductType);

                var mapProductTypeModel = _mapper.Map<ProductTypeViewModel>(result);

                return Result<ProductTypeViewModel>.Ok(mapProductTypeModel);
            }
            catch (Exception ex)
            {
                return Result<ProductTypeViewModel>.Fail("There was an error editing the product type: " + ex.Message);
            }
        }

        public async Task<Result<ProductTypeViewModel>> Post(ProductTypeViewModel productType)
        {
            try
            {

                var mapProductType = _mapper.Map<ProductType>(productType);

                var result = await _productTypeRepository.Post(mapProductType);

                var mapProductTypeModel = _mapper.Map<ProductTypeViewModel>(result);

                return Result<ProductTypeViewModel>.Ok(mapProductTypeModel);
            }
            catch (Exception ex)
            {
                return Result<ProductTypeViewModel>.Fail("There was an error registering the product type: " + ex.Message);
            }
        }
    }
}
