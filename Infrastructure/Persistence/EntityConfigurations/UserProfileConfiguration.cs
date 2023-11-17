using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(x => x.UserProfile)
                .WithOne()
                .HasForeignKey<UserProfile>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
