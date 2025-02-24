using AutoMapper;
using clean_architecture_dotnet.Application.ViewModels.Products;
using clean_architecture_dotnet.Application.ViewModels.Sales;
using clean_architecture_dotnet.Application.ViewModels.Users;
using clean_architecture_dotnet.Domain.Entities.Products;
using clean_architecture_dotnet.Domain.Entities.Sales;
using clean_architecture_dotnet.Domain.Entities.Users;

namespace clean_architecture_dotnet.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Users Profile

            CreateMap<UserViewModel, User>();
            CreateMap<UserAddressViewModel, UserAddress>();
            CreateMap<UserContactViewModel, UserContact>();

            #endregion

            #region Products Profile

            CreateMap<ProductViewModel, Product>();
            CreateMap<ProductTypeViewModel, ProductType>();

            #endregion

            #region Sales Profile

            CreateMap<SaleViewModel, Sale>();

            #endregion
        }
    }
}
