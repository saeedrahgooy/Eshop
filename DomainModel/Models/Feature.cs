using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public ICollection<CategoryFeature> CategoryFeatures { get; set; }
        public ICollection<ProductFeatureValue> ProductFeatureValues { get; set; }
        public Feature()
        {
            CategoryFeatures = new HashSet<CategoryFeature>();
            ProductFeatureValues = new HashSet<ProductFeatureValue>();

        }
    }
}
