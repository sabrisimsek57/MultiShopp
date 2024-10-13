using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogService.ProductImageService;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductImageService _productImageService;

        public _ProductDetailImageSliderComponentPartial(IHttpClientFactory httpClientFactory, IProductImageService productImageService = null)
        {
            _httpClientFactory = httpClientFactory;
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {


            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            return View(values);    

            //var client = _httpClientFactory.CreateClient();

            //var respınseMessage = await client.GetAsync("https://localhost:7000/api/ProductImages/ProductImagesByProductId/" + id);
          
            //if (respınseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await respınseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsondata);
            //    return View(values);
            //}
            //return View();

        }
    }
    
}
