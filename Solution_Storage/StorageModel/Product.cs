using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageModel
{
    public class Product
    {
        public string Name { get; set; }
        public long Barcode { get; set; }

        public Product (string name, long barcode)
        {
            Name = name;
            Barcode = barcode;
        }
    }
}
