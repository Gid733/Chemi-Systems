using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChemiSystems.Infrastructure;
using ChemiSystems.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChemiSystems.Helpers
{
    public class StorageHelper
    {
        public static List<ProductInCartViewModel> GetProductsLocal(string jsonLocalStorageObj, ChemiContext db)
        {
            JObject obj = null;
            if(jsonLocalStorageObj != null)
            obj = JObject.Parse(jsonLocalStorageObj);

            Dictionary<Guid, int> dict;
            try
            {
                dict = obj.ToObject<Dictionary<Guid, int>>();
            }
            catch (JsonReaderException)
            {
                return null;
            }
            //Creating product list from base by Id
            List<ProductInCartViewModel> productList = dict.Select(d => new ProductInCartViewModel
            {
                Product = db.Products.Include("ProductImage").Include("ProductCategory").FirstOrDefault(a => a.Id == d.Key),
                Amount = d.Value
            }).ToList();

            return productList;
        }
    }
}