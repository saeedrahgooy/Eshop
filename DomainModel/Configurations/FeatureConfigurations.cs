using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Configurations
{
    public class FeatureConfigurations : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(x => x.FeatureID);
            builder.HasMany(x => x.ProductFeatureValues)
                .WithOne(x => x.Feature)
                .HasForeignKey(x => x.FeatureID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.FeatureName).HasMaxLength(100);


        }
    }
}
