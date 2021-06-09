using System.Collections.Generic;

namespace DataLayer.Entity
{
    public class Product : BaseEntity
    {
        public enum EProductType
        {
            // DON'T EVER CHANGE THE NUMERIC VALUES FOR THIS ENUMERATIONs
            FW_FISH = 1,
            SW_FISH,
            P_FISH,
            CRAB_FISH,
            FW_PLANT,
            P_PLANT,
            FILTER,
            CO2,
            FOOD,
            TANK
        }
        public string title { get; set; }
        public string description { get; set; }
        public EProductType the_type { get; set; }
        public List<Stock> Stock { get; set; }
        public List<Order> Orders { get; set; }

        public Product() { }

        public Product(string name, string desc, EProductType type)
        {
            title = name;
            description = desc;
            the_type = type;
        }

        public string FullProductInfo
        {
            get
            {
                return $"{ title } { description } {the_type } {Stock}";
            }
        }
    }
}
