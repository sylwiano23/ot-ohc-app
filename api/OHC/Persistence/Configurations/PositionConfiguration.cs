using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(e => e.Id).HasColumnName("PositionID");

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Description)
                .IsRequired();
        }
    }
}
