using MyShop.Entities;

namespace MyShop.DAL.Repositories
{
    public interface IOrderRepository
    {
        void OrderRegistration(Order order);
        List<Order> GetAllOrder();
        Order FindOrder(int id);

    }
}
