using Reporter.Models.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reporter.Services.Services.Abstractions
{
    public interface IMarketService
    {
        IProduct SearchForProduct(string name);
        void AddProduct(IProduct product);
        IProduct SellProduct(string name);
        void DeleteProduct(IProduct product);
        void DeserializeAction(string actionName);

        Action<IAction> AddActionReportDel { get; set; }
        Func<string, IAction> SearchForActionDel { get; set; }
    }
}
