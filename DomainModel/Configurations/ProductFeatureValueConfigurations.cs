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
    public class ProductFeatureValueConfigurations : IEntityTypeConfiguration<ProductFeatureValue>
    {
        public void Configure(EntityTypeBuilder<ProductFeatureValue> builder)
        {
            builder.HasKey(x => x.ProductFeatureValueID);
            builder.Property(x => x.FeatureValue).HasMaxLength(200);
        }
    }
}
