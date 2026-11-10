using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
    }
}
