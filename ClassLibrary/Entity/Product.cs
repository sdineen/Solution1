using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Entity
{
    public class Product
    {
        //https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types#non-nullable-properties-and-initialization

        private string? id; //nullable backing field
        public string Id //non-nullable property
        {
            get => id ??
                   throw new InvalidOperationException("Uninitialized property");
            set => id = value;
        }

        public string Name { get; set; } = null!; //null forgiving operator
        public double CostPrice { get; set; }
        public virtual double RetailPrice { get; set; }
        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public Product()
        {

        }
        public Product(string id, string name, double costPrice, double retailPrice = 0)
        {
            Id = id;
            Name = name;
            CostPrice = costPrice;
            RetailPrice = retailPrice;
        }

        public override string? ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj) =>
            obj is Product ? ((Product)obj).Id == Id : false;

        public override int GetHashCode() => HashCode.Combine(Id);

    }
}
