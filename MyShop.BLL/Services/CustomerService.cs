using MyShop.DAL.Repositories;
using MyShop.Entities;

namespace MyShop.BLL.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _CustomerRepository;

        public CustomerService()
        {
            _CustomerRepository = new CustomerRepository();
        }




        public void AddCustomer(string firstname, string lastname, string username, string phone, string address)
        {
            if (string.IsNullOrWhiteSpace(firstname) ||
      string.IsNullOrWhiteSpace(lastname) ||
      string.IsNullOrWhiteSpace(username) ||
      string.IsNullOrWhiteSpace(phone))
            {
                Console.WriteLine("خطا: اطلاعات مشتری ناقص است!");
                return;
            }

            Customer customer = new();
            customer.FirstName = firstname;
            customer.LastName = lastname;
            customer.UserName = username;
            customer.Phone = phone;
            customer.Address = address;
            customer.CreatedAt = DateTime.Now;
            _CustomerRepository.Add(customer);


        }
        public List<Customer> AllCustomer()
        {
            return _CustomerRepository.GetAllCustomer();
        }



    }
}
