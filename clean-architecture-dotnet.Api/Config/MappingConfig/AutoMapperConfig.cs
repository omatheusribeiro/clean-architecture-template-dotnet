using clean_architecture_dotnet.Application.Mappings;

namespace clean_architecture_dotnet.Api.Config.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile),
                    typeof(ViewModelToDomainMappingProfile));
        }
    }
}
