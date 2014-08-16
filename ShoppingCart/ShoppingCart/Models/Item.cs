using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public class Item
    {
        public string Category { get; set; }

        public string Description { get; set; }

        public string IconUrl { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string ProductCode { get; set; }

        public int Rating { get; set; }

        public List<string> Tags { get; set; }
    }
}