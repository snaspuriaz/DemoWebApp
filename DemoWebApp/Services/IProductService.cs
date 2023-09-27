using DemoWebApp.Models;

namespace DemoWebApp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}