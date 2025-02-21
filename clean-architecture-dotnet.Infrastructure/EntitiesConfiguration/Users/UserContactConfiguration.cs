using clean_architecture_dotnet.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace clean_architecture_dotnet.Infrastructure.EntitiesConfiguration.Users
{
    public class UserContactConfiguration : IEntityTypeConfiguration<UserContact>
    {
        public void Configure(EntityTypeBuilder<UserContact> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.CreationDate).IsRequired();

            builder.Property(p => p.ChangeDate);

            builder.Property(p => p.Email).IsRequired();

            builder.Property(p => p.PhoneNumber).IsRequired();

            builder
            .HasOne(uc => uc.User)
            .WithMany(u => u.Contacts)
            .HasForeignKey(uc => uc.Id);

            builder.HasData(
                new UserContact
                {
                    Id = 1,
                    CreationDate = DateTime.UtcNow,
                    ChangeDate = null,
                    Email = "usertest@test.com.br",
                    PhoneNumber = "+00 (00) 00000-0000",
                }); ;
        }
    }
}
