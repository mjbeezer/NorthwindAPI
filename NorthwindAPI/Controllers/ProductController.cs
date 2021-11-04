using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("getAll")]
        public List<Product> GetAllProducts()
        {
            List<Product> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Products.ToList();
            }
            return result;
        }

        [HttpGet("{productName}")]
        public List<Product> GetByProductName(string productName)
        {
            List<Product> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Products.Where(a => a.ProductName == productName).ToList();
            }
            return result;
        }

        [HttpDelete("delete/{id}")]
        public Product DeleteByProductId(int id)
        {
            Product result = null;
            List<OrderDetail> resultOne = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                resultOne = context.OrderDetails.Where(o => o.ProductId == id).ToList();                
                foreach(OrderDetail i in resultOne)
                {
                    context.OrderDetails.Remove(i);
                }                
                context.SaveChanges();
                
                result = context.Products.Find(id);
                if(result != null)
                {
                    context.Products.Remove(result);
                }                
                context.SaveChanges();
            }
            return result;
        }
    }
}
