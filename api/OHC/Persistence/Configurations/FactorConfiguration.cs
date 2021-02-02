using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class FactorConfiguration : IEntityTypeConfiguration<Factor>
    {
        public void Configure(EntityTypeBuilder<Factor> builder)
        {
            builder.Property(e => e.Id).HasColumnName("FactorID");

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.FactorType).IsRequired();
            builder.Property(e => e.FactorType).HasMaxLength(50).HasConversion(e => e.ToString(), e => (FactorTypeEnum)Enum.Parse(typeof(FactorTypeEnum), e));           
        }
    }
}
