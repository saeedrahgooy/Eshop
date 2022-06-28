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
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductID);
            builder.Property(x => x.ProductName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();

            builder.HasMany(x => x.ProductFeatureValues)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.OrderDetails)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.RelatedProducts)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasMany(x => x.RelatedProducts)
            //    .WithOne(x => x.RelatedTo)
            //    .HasForeignKey(x => x.RelatedToID)
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.ProductKeyWords)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
