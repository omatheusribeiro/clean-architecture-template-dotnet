﻿using AutoMapper;
using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.Services.Products.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Products;
using clean_architecture_dotnet.Domain.Entities.Products;
using clean_architecture_dotnet.Infrastructure.Repositories.Products.Interfaces;

namespace clean_architecture_dotnet.Application.Services.Products
{
    public class ProductTypeService : IProductTypeService
    {
        private IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductTypeService(IMapper mapper, IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProductTypeViewModel>> Put(ProductTypeViewModel productType)
        {
            try
            {
                var mapProductType = _mapper.Map<ProductType>(productType);

                var result = await _productTypeRepository.Put(mapProductType);

                var mapProductTypeModel = _mapper.Map<ProductTypeViewModel>(result);

                return Result<ProductTypeViewModel>.Ok(mapProductTypeModel);
            }
            catch (Exception ex)
            {
                return Result<ProductTypeViewModel>.Fail("There was an error editing the product type: " + ex.Message, 500);
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
                return Result<ProductTypeViewModel>.Fail("There was an error registering the product type: " + ex.Message, 500);
            }
        }
    }
}
