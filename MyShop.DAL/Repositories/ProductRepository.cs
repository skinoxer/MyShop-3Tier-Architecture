using MyShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.DAL.Repositories
{
    public class ProductRepository : IProductRepository 
    {
        private AppDbContext _context = new AppDbContext();
       public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
         
        }

        public void Delete(int id)
        {
          var product =  GetById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
