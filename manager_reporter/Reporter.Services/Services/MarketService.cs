using Newtonsoft.Json;
using Reporter.Models.Models;
using Reporter.Models.Models.Abstractions;
using Reporter.Services.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Action = Reporter.Models.Models.Action;

namespace Reporter.Services.Services
{
    public class MarketService : IMarketService
    {
        private List<IProduct> _allProducts = new List<IProduct>();
        public Action<IAction> AddActionReportDel { get; set; }
        public Func<string, IAction> SearchForActionDel { get; set; }

        public void AddProduct(IProduct product)
        {
            InvoceAction("AddProduct", product);
            var productExists = SearchForProduct(product.Name);
            if (productExists != null)
            {
                productExists.Count += product.Count;
            }
            else
            {
                _allProducts.Add(product);
            }
        }

        public void DeleteProduct(IProduct product)
        {
            InvoceAction("DeleteProduct", product);
            if (product.Count == 1)
            {
                _allProducts.Remove(product);
            }
            else
            {
                product.Count--;
            }
        }

        public IProduct SearchForProduct(string name)
        {
            foreach(var item in _allProducts)
            {
                if(item.Name.ToLower() == name.ToLower())
                {
                    InvoceAction("SearchForProduct", item);
                    return item;
                }
            }

            return null;
        }

        public IProduct SellProduct(string name)
        {
            var product = SearchForProduct(name);
            if(product != null)
            {
                var userProduct = new Product() 
                    { Name = product.Name, Price = product.Price, Count = 1 };

                DeleteProduct(product);
                InvoceAction("SellProduct", userProduct);
                return userProduct;
            }

            return null;
        }

        private void InvoceAction(string actionName, IProduct product)
        {
            var productJson = JsonConvert.SerializeObject(product); // convert C# object in string of json
            var action = new Action()
            {
                Name = actionName,
                Time = DateTime.Now,
                Json = productJson
            };

            AddActionReportDel.Invoke(action);
        }
        
        public void DeserializeAction(string actionName)
        {
            IProduct product = null;
            var action = SearchForActionDel.Invoke(actionName);
            product = JsonConvert.DeserializeObject<Product>(action.Json);
            AddProduct(product);
            InvoceAction($"{actionName} was Deserialized", product);
        }
    }
}
