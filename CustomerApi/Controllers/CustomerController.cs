using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerApi.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CustomerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        //[Route("/GetCustomer")]
        public IActionResult GetAllCustomers()
        {
            var availableCustomers = dbContext.Customers.ToList();
            return Ok(availableCustomers);
        }

        //[HttpGet]
        // [Route("/GetCustomerById{id:int}")]
        [HttpGet("{id}")]
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
        //[Route("/AddCustomer")]
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
       // [Route("/UpdateCustomer")]
        public IActionResult updateCustomer( UpdateCustomer updateCustomer)
        {
            
            if(updateCustomer==null || updateCustomer.CustomerCode == 0)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                //var customer = new Customers()
                //{
                //    Name = updateCustomer.Name,
                //    Address = updateCustomer.Address,
                //    Email = updateCustomer.Email,
                //    MobileNo = updateCustomer.MobileNo,
                //    GeoLocation = updateCustomer.GeoLocation

                //};

                var customer = dbContext.Customers.Find(updateCustomer.CustomerCode);
                if (customer == null)
                {
                    return NotFound($"Product not found with id {updateCustomer.CustomerCode}");
                }
                customer.Name = updateCustomer.Name;
                customer.Address = updateCustomer.Address;
                customer.Email = updateCustomer.Email;
                customer.MobileNo = updateCustomer.MobileNo;
                customer.GeoLocation = updateCustomer.GeoLocation;
                dbContext.SaveChanges();

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //[Route("/DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var customer = dbContext.Customers.Find(id);

                if (customer == null)
                {
                    return NotFound();
                }

                dbContext.Customers.Remove(customer);
                dbContext.SaveChanges();

                return Ok("Record Deleted Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
