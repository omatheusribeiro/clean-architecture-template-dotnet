using clean_architecture_dotnet.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace clean_architecture_dotnet.Infrastructure.EntitiesConfiguration.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.CreationDate).IsRequired();

            builder.Property(p => p.ChangeDate);

            builder.Property(p => p.FirstName).IsRequired();

            builder.Property(p => p.LastName).IsRequired();

            builder.Property(p => p.Document).IsRequired();

            builder
                .HasMany(u => u.Contact)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new User
                {
                    Id = 1,
                    CreationDate = DateTime.UtcNow,
                    ChangeDate = null,
                    FirstName = "User",
                    LastName = "Test",
                    Document = "00.000.000/0000-00",
                }); ;
        }
    }
}
