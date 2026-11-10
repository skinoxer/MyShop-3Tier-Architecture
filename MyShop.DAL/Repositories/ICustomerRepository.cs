using MyShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.DAL.Repositories
{
    public  interface ICustomerRepository
    {
        void Add(Customer customer);
        void Delete(int id);
        void update(Customer customer);
        List<Customer> GetAllCustomer();
        Customer? GetById(int id);
    }
}
