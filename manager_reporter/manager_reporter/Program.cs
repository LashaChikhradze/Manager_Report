using Reporter.Models.Models;
using Reporter.Models.Models.Abstractions;
using Reporter.Services.Services;
using Reporter.Services.Services.Abstractions;
using System;

namespace manager_reporter
{
    class Program
    {
        static void Main(string[] args)
        {
            IMarketService marker = new MarketService();
            IManagerService manager = new ManagerService();
            marker.AddActionReportDel = manager.AddActionInReportList;

            IProduct product = new Product() { Name = "Coffee", Count = 3, Price = 13 };

            marker.AddProduct(product);
            marker.SellProduct("Coffee");

            marker.SearchForActionDel = manager.SearchForAction;
            marker.DeserializeAction("SellProduct");

            Console.WriteLine("Hello World!");
        }
    }
}
