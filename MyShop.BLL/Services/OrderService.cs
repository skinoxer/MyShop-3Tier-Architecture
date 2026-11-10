using MyShop.DAL.Repositories;
using MyShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.BLL.Services
{
    public class OrderService 
    {
        private ICustomerRepository _CustomerRepository ;

        private readonly IOrderRepository _iOrderRepository;
        private IProductRepository _ProductRepository;

        public OrderService()
        {
            _iOrderRepository = new OrderRepository();
            _CustomerRepository = new CustomerRepository();
            _ProductRepository = new ProductRepository();

        }

        public void CreateOrder(int customerId, int productId, int count)
        {
            if(count <= 0)
            {
                Console.WriteLine("تعداد باید بیشتر از صفر باشد");
                return;
            }
            var customer = _CustomerRepository.GetById(customerId);
            if (customer == null)
            {
                Console.WriteLine("مشتری پیدا نشد");
                return;
            }
            var product = _ProductRepository.GetById(productId);
            if (product == null)
            {
                Console.WriteLine("کالا پیدا نشد");
                return;
            }
            if(product.Stock < count)
            {
                Console.WriteLine("موجودی انبار کافی نیست");
                return;
            }
            product.Stock -= count;
            _ProductRepository.Update(product);
            OrderItem orderitem = new();
            orderitem.Count = count;
            orderitem.ProductId = productId;
            orderitem.UnitPrice = product.Price;
            Order order = new();
            order.CustomerId = customerId;
            order.OrderDate = DateTime.Now;
            order.Status = OrderStatus.Paid;
            order.TotalPrice = count * product.Price;
            order.Items.Add(orderitem);
            _iOrderRepository.OrderRegistration(order);
        }
        public List<Order> GetAllOrders()
        {
            return _iOrderRepository.GetAllOrder();
        }



    }
}
