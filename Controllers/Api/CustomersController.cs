using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;
using vidly.Dtos;
using vidly.Models;
using System.Data.Entity;

namespace vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //public IEnumerable<CustomerDTO> GetCustomers()
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers.Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customers = customersQuery.ToList().Select(Mapper.Map<Customer, CustomerDTO>);

           return Ok(customers);
        }


       // public CustomerDTO GetCustomer(int id)
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer =  _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();  // BadRequest();

            //return Mapper.Map<Customer, CustomerDTO>(customer);
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }


        [HttpPost]
       // public CustomerDTO CreateCustomer(CustomerDTO customerDto)
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            //return customerDto;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }


        [HttpPut]
        //public void UpdateCustomer(int id,CustomerDTO customerDto)
        public IHttpActionResult UpdateCustomer(int id,CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                 return  BadRequest();

            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            //Mapper.Map<CustomerDTO, Customer>(customerDto, customerInDb);
            Mapper.Map(customerDto, customerInDb);

            /*customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;*/

            _context.SaveChanges();
            //from me  :D
            return Ok();
        }



        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            //from me  :D
            return Ok();
        }
    }
}
