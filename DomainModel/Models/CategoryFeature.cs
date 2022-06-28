﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class CategoryFeature
    {
        public int CategoryFeatureID { get; set; }
        public int FeatureID { get; set; }
        public int CategoryID { get; set; }
        public Feature Feature { get; set; }
        public Category Category { get; set; }
    }
}
