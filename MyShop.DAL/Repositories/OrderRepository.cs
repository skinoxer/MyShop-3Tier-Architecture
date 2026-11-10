using Microsoft.EntityFrameworkCore;
using MyShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private AppDbContext _context = new AppDbContext();

        public List<Order> GetAllOrder()
        {
            return _context.Orders
                    .Include(o => o.Items)
                    .ToList();


        }

        public Order? FindOrder(int id)
        {
            return _context.Orders
                     .Include(o => o.Items)
                     .FirstOrDefault(o => o.Id == id);
        }

        public void OrderRegistration(Order order)
        {
            if (order == null)
            {
                return;
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
