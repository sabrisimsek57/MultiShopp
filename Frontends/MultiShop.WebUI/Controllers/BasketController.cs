using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogService.ProductService;


namespace MultiShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public BasketController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task< IActionResult> Index()
        {
            var values = await _basketService.GetBasket();
            return View();
        }


        public async Task <IActionResult> AddBasketItem(string ProductId)
        {
            var values = await _productService.GetByIdProductAsync(ProductId);
            var item = new BasketItemDto
            {
                Price = values.ProductPrice,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Quantity = 1
            };
            await _basketService.AddBasketItem(item);
            return RedirectToAction("Index");
        }

    }
}
