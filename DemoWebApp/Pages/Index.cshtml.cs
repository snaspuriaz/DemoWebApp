using DemoWebApp.Models;
using DemoWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoWebApp.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        private readonly IProductService _ProdService;
        public IndexModel(IProductService productService)
        {
            _ProdService = productService;
        }
        public List<Product> _Prods;
        public void OnGet()
        {
            //ProductService prodSer = new ProductService();
              _Prods = _ProdService.GetProducts();

        }
    }
}