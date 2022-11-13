using System;
using System.Collections.Generic;

namespace ReverseEngineer
{
    public partial class LineItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string ProductId { get; set; } = null!;
        public int? OrderId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
