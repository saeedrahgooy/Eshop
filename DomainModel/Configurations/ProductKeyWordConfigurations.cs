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
    public class ProductKeyWordConfigurations : IEntityTypeConfiguration<ProductKeyWord>
    {
        public void Configure(EntityTypeBuilder<ProductKeyWord> builder)
        {
            builder.HasKey(x => x.ProductKeyWordID);
            
        }
    }
}
