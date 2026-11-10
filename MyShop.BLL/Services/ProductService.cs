using MyShop.DAL.Repositories;
using MyShop.Entities;

namespace MyShop.BLL.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();

        }

        public void AddProduct(string name, decimal price, string description, int stock)
        {
            if (string.IsNullOrWhiteSpace(name))

            {
                Console.WriteLine("enter valid name");
                return;
            }


            if (price <= 0)
            {
                Console.WriteLine("enter valid price");
                return;
            }
            if (stock <= 0)
            {
                Console.WriteLine("enter a valid stock number");
                return;

            }
            Product product = new();
            product.Name = name;
            product.Price = price;
            product.Stock = stock;
            product.Description = description;
            _productRepository.Add(product);

        }
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }
    }
}
