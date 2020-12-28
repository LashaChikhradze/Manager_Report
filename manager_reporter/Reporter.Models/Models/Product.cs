using Reporter.Models.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reporter.Models.Models
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
