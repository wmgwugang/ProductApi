using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    public class ProductsController : ApiController
    {
        readonly List<Product> _products = new List<Product>(){
            new Product() {Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1},
            new Product() {Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M},
            new Product() {Id = 3, Name = "Hamar", Category = "Hardware", Price = 16.99M}
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        
        public IHttpActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _products.Remove(product);
            return Ok();
        }
    }
}
