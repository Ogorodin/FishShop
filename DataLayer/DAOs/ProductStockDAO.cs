using System;
using DataLayer.Entity;
using static DataLayer.Entity.Product;

namespace DataLayer.DAOs
{
    public class ProductStockDAO : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public EProductType ProductType { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime PriceDate { get; set; }
    }
}
