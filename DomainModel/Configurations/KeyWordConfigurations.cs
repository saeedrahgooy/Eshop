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
    public class KeyWordConfigurations : IEntityTypeConfiguration<KeyWord>
    {
        public void Configure(EntityTypeBuilder<KeyWord> builder)
        {
            builder.HasKey(x => x.KeyWordID);
            builder.Property(x => x.KeyWordText).HasMaxLength(100);

            builder.HasMany(x => x.ProductKeyWords)
                .WithOne(x => x.KeyWord)
                .HasForeignKey(x => x.KeyWordID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
