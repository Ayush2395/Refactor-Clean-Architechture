using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.Property(x => x.Id)
                .HasMaxLength(100)
                .HasDefaultValueSql("newid()");

            builder.OwnsOne(x => x.Colour);
        }
    }
}
