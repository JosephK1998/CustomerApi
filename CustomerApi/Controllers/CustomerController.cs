using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerApi.Models.Entities;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CustomerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("/GetCustomer")]
        public IActionResult GetAllCustomers()
        {
            var availableCustomers = dbContext.Customers.ToList();
            return Ok(availableCustomers);
        }

        [HttpGet]
        [Route("/GetCustomerById{id:int}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = dbContext.Customers.Find(id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        [Route("/AddCustomer")]
        public IActionResult AddCustomer(AddCustomer addCustomer)
        {
            var customerentity = new Customers()
            {
                Name = addCustomer.Name,
                Address = addCustomer.Address,
                Email = addCustomer.Email,
                MobileNo = addCustomer.MobileNo,
                GeoLocation = addCustomer.GeoLocation
            };

            dbContext.Customers.Add(customerentity);
            dbContext.SaveChanges();

            return Ok(customerentity);
        }

        [HttpPut]
        [Route("/UpdateCustomer")]
        public IActionResult updateCustomer(int id, UpdateCustomer updateCustomer)
        {
            var customer = dbContext.Customers.Find(id);

            if (customer is null)
            {
                return NotFound();
            }

            customer.Name = updateCustomer.Name;
            customer.Address = updateCustomer.Address;
            customer.Email = updateCustomer.Email;
            customer.MobileNo = updateCustomer.MobileNo;
            customer.GeoLocation = updateCustomer.GeoLocation;

            dbContext.SaveChanges();

            return Ok(customer);
        }

        [HttpDelete]
        [Route("/DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = dbContext.Customers.Find(id);

            if (customer is null)
            {
                return NotFound();
            }

            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
