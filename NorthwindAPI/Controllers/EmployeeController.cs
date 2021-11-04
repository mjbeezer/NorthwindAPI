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
    public class EmployeeController : ControllerBase
    {
        [HttpGet("getAll")]
        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Employees.ToList();
            }
            return result;
        }

        [HttpGet("{title}")]
        public List<Employee> GetByTitle(string title)
        {
            List<Employee> result = null;
            using (NorthwindContext context = new NorthwindContext())
            {
                result = context.Employees.Where(a => a.Title == title).ToList();
            }
            return result;
        }

        [HttpPost("Add")]
        public Employee CreateEmployee(string firstName, string lastName, string title)
        {
            Employee newEmployee = new Employee();
            newEmployee.FirstName = firstName;
            newEmployee.LastName = lastName;
            newEmployee.Title = title;
            using (NorthwindContext context = new NorthwindContext())
            {
                context.Employees.Add(newEmployee);
                context.SaveChanges();
            }
            return newEmployee;
        }
    }
}
