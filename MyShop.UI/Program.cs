using MyShop.BLL.Services;
using MyShop.Entities;

//Add Product
ProductService productService = new();

productService.AddProduct(name: "laptop", price: 22, stock: 2, description: "this is laptop");
foreach (var item in productService.GetAllProducts())
{
    Console.WriteLine($"شناسه: {item.Id} | نام: {item.Name} | قیمت: {item.Price} | موجودی: {item.Stock}");
}

//Add Customer
CustomerService CustomerService = new CustomerService();
CustomerService.AddCustomer(firstname: "mehdi", lastname: "almasifar", username: "skinoxer", phone: "0999", address: "xxx");

foreach (var item1 in CustomerService.AllCustomer())
{
    Console.WriteLine($"شناسه: {item1.Id} | نام و فامیل: {item1.FirstName} {item1.LastName} | نام کاربری: {item1.UserName} | تلفن: {item1.Phone}");
 
}
//Create Order
OrderService orderService = new();
orderService.CreateOrder(customerId: 1, productId: 1, 1);
foreach (var item in orderService.GetAllOrders()) 
{
    Console.WriteLine($"{item.Id},{item.CustomerId},{item.TotalPrice}");
    foreach (var orderItem in item.Items)
    {
        Console.WriteLine($"   -> کالای شماره: {orderItem.ProductId} | تعداد: {orderItem.Count} | قیمت واحد: {orderItem.UnitPrice}");
    }

}