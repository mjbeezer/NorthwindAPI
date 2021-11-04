using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("getAll")]
        public List<Customer> GetAllCustomers()
        {
            List<Customer> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Customers.ToList();
            }
            return result;
        }

        [HttpGet("{region}")]
        public List<Customer> GetByRegion(string region)
        {
            List<Customer> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Customers.Where(a => a.Region == region).ToList();
            }
            return result;
        }

        [HttpPost("Add")]
        public Customer CreateCustomer(string companyName, string city, string address)
        {
            Customer newCustomer = new Customer();
            newCustomer.CompanyName = companyName;
            newCustomer.City = city;
            newCustomer.Address = address;
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }
            return newCustomer;
        }
    }
}
