using ClassLibrary.Entity;
using ClassLibrary.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IEcommerceService ecommerceService;

        public ProductController(IEcommerceService ecommerceService)
        {
            this.ecommerceService = ecommerceService;
        }

        [HttpGet]
        [Route("{partOfName ?}")]
        public async Task<IActionResult> GetByNameAsync(string? partOfName)
        {
            ICollection<Product> products =
            await ecommerceService.SelectProductsAsync(partOfName);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Product product)
        {
            bool created = await ecommerceService.CreateProductAsync(product);
            if (!created)
            {
                return Conflict($"{product.Id} already exists");
            }
            return Ok(product);
        }
        // api/product/id
        [HttpGet("{id:regex(^p\\d+$)}")]
        public async Task<IActionResult> GetById(string id)
        {
            var products = await ecommerceService.SelectProductsAsync(null);
            Product product = products.First(p => p.Id == id);
            return Ok(product);
        }

    }

}
