using System;
using System.Collections.Generic;

namespace DataLayer.Entity
{
    public class Order : BaseEntity
    {
        public DateTime date_time { get; set; }
        public double total_price { get; set; }
        public User User { get; set; }
        public List<Product> ProductList { get; set; }

    }
}