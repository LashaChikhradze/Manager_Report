using System;
using System.Collections.Generic;
using System.Text;

namespace Reporter.Models.Models.Abstractions
{
    public interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        int Count { get; set; }
    }
}
