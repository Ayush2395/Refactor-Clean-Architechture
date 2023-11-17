using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.Property(x => x.Id)
                .HasMaxLength(100)
                .HasDefaultValueSql("newid()");

            builder.Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(x => x.List)
                .WithMany(x => x.Items)
                .HasForeignKey(fk => fk.ListId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
