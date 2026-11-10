using MyShop.Entities;

namespace MyShop.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private AppDbContext _context = new AppDbContext();
        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _context.Customers.Remove(user);
                _context.SaveChanges();
            }
      

        }

        public List<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }

        public Customer? GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        public void update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}
