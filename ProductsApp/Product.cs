using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp
{
    enum ProductCategories
    {
        Food,
        Technic
    }

    internal class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
        public ProductCategories Category { get; set; }
    }
}
