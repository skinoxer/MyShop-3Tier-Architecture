using MyShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.DAL.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Delete(int id);
        void Update(Product product);
        Product? GetById(int id);
        List<Product> GetAll();
    }
}
