using GcpWebServing.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using System.Linq;
using OnlinestoreContext;

namespace GcpWebServing.Controllers
{
    public class ProductsController : Controller
    {
        public List<Models.Product> GetInitialProductsList()
        {
            List<Models.Product> products = new List<Models.Product>();

            //UpdateRecordinDB();
            //products = GetDataFromDatabase(string.Empty);

            return products;
        }

        public JsonResult SearchProductsList(string filterText)
        {
            List<Models.Product> products = new List<Models.Product>();

            if (!string.IsNullOrWhiteSpace(filterText))
            {
                using (OnlineStoreDataContext context = new OnlineStoreDataContext())
                {
                    var query = (from p in context.Products
                                 where p.Name.ToLower().Contains(filterText.ToLower().Trim())
                                 select p).Take(15);


                    foreach (OnlinestoreContext.Product prod in query)
                    {
                        products.Add(new Models.Product
                        {
                            sku = prod.Sku,
                            name = prod.Name,
                            type = prod.Type,
                            price = prod.Price.HasValue ? Convert.ToDouble(prod.Price.Value) : 0,
                            upc = prod.Upc,
                            shipping = prod.Shipping.HasValue ? Convert.ToDouble(prod.Shipping.Value) : 0,
                            description = prod.Description,
                            manufacturer = prod.Manufacturer,
                            model = prod.Model,
                            url = prod.Url,
                            image = !string.IsNullOrWhiteSpace(prod.Image) ? prod.Image.Replace("http:", "https:") : string.Empty
                        });
                    }
                };
            }

            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}