using AutoMapper;
using clean_architecture_dotnet.Application.ViewModels.Products;
using clean_architecture_dotnet.Application.ViewModels.Sales;
using clean_architecture_dotnet.Application.ViewModels.Users;
using clean_architecture_dotnet.Domain.Entities.Products;
using clean_architecture_dotnet.Domain.Entities.Sales;
using clean_architecture_dotnet.Domain.Entities.Users;

namespace clean_architecture_dotnet.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            #region Users Profile

            CreateMap<User, UserViewModel>();
            CreateMap<UserAddress, UserAddressViewModel>();
            CreateMap<UserContact, UserContactViewModel>();

            #endregion

            #region Products Profile

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductType, ProductTypeViewModel>();

            #endregion


            #region Sales Profile

            CreateMap<Sale, SaleViewModel>();

            #endregion
        }
    }
}
