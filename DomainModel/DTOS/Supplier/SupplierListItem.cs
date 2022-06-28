﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTOS.Supplier
{
    public class SupplierListItem
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public int ProductCount { get; set; }
    }
}
