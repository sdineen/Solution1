using System;
using System.Collections.Generic;

namespace ReverseEngineer
{
    public partial class Order
    {
        public Order()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int OrderStatus { get; set; }
        public string AccountId { get; set; } = null!;

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
