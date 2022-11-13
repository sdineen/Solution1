using System;
using System.Collections.Generic;

namespace ReverseEngineer
{
    public partial class Product
    {
        public Product()
        {
            LineItems = new HashSet<LineItem>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public double CostPrice { get; set; }
        public double RetailPrice { get; set; }
        public byte[]? RowVersion { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
