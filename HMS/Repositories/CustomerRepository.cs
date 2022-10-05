using HMS.Context;
using HMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace HMS.Repositories
{
    public class CustomerRepository
    {
        private readonly HMSDbContext _context;
        public CustomerRepository(HMSDbContext hmsdbcontext)
        {
            _context = hmsdbcontext;
        }

        public bool Create(Customer customer)
        {
            if (customer == null)
            {
                Console.WriteLine("Customer is Null");
                return false;
            }
            else
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true;
            }
        }

        public bool Update( Customer updatedCustomer)
        {
            
                _context.Update(updatedCustomer);
                _context.SaveChanges();
                return true;
      
        }

        public Customer GetById(int customerId)
        {
            return _context.Customers
                .Include(c => c.User)
                .SingleOrDefault(c => c.Id == customerId);
        }

        public Customer GetbyEmail(string email)
        {
            return _context.Customers
                .Include(c => c.User)
                .FirstOrDefault(c => c.User.Email == email);
        }

        public bool Delete(int customerId)
        {
            var customer = _context.Customers
               .FirstOrDefault(x => x.Id == customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer is Null");
                return false;
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return true;
        }

        public List<Customer> List()
        {
            return _context.Customers
                .Include(c => c.User)
                .ToList();
        }
    }
}
