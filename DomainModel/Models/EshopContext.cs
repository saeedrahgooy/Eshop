using DomainModel.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace DomainModel.Models
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options):base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryFeature> CategoryFeatures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RelatedProduct> RelatedProducts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductFeatureValue> ProductFeatureValues { get; set; }
        public DbSet<ProductKeyWord> ProductKeyWords { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration<CategoryFeature>(new CategoryFeatureConfigurations());
            modelBuilder.ApplyConfiguration<Product>(new ProductConfigurations());
            modelBuilder.ApplyConfiguration<Feature>(new FeatureConfigurations());
            modelBuilder.ApplyConfiguration<KeyWord>(new KeyWordConfigurations());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfigurations());
            modelBuilder.ApplyConfiguration<ProductFeatureValue>(new ProductFeatureValueConfigurations());
            modelBuilder.ApplyConfiguration<ProductKeyWord>(new ProductKeyWordConfigurations());
            modelBuilder.ApplyConfiguration<RelatedProduct>(new RelatedProductConfigurations());
            modelBuilder.ApplyConfiguration<Supplier>(new SupplierConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
