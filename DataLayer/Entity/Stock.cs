using System;

namespace DataLayer.Entity
{
    public class Stock : BaseEntity
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime PriceDate { get; set; }
        public Product Product { get; set; }

        public Stock() { }

        public Stock(double price, int quantity, DateTime priceDate, Product product)
        {
            Price = price;
            Quantity = quantity;
            PriceDate = priceDate;
            Product = product;
        }
    }
}