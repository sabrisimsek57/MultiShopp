using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogService.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductDetailService _productDetailService;
        public _ProductDetailInformationComponentPartial(IHttpClientFactory httpClientFactory, IProductDetailService productDetailService)
        {
            _httpClientFactory = httpClientFactory;
            _productDetailService = productDetailService;
        }


        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(values);

            //var client1 = _httpClientFactory.CreateClient();

            //var client = _httpClientFactory.CreateClient();
            //var respınseMessage = await client.GetAsync("https://localhost:7000/api/ProductDetails/GetProductDetailByProductId/" + id);
            //if (respınseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await respınseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsondata);
            //    return View(values);
            //}

            //return View();
        }
    }
   
}
