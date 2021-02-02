using Domain.Entities;
using Domain.Entities.Survey;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configurations
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.Property(e => e.Id).HasColumnName("SurveyID");

            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.FactorName).IsRequired();            
            builder.Property(e => e.Place).IsRequired();
            builder.Property(e => e.Result).IsRequired();
            builder.Property(e => e.FactorType).IsRequired();
            builder.Property(e => e.IsSurveySuspend).IsRequired();

            builder.Property(e => e.FactorType).HasMaxLength(50).HasConversion(e => e.ToString(), e => (FactorTypeEnum)Enum.Parse(typeof(FactorTypeEnum), e));
        }
    }
}
