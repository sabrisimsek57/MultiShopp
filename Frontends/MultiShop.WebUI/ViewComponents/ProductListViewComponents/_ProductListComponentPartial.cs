using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogService.ProductService;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService  _productService;

        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory, IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
        }

        string id2 = "66224a3a542696be99bf3bcf";
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            id = id2;
            var values = await _productService.GetProductsWithCategoryByCatetegoryIdAsync(id);
            return View(values);

            //var client = _httpClientFactory.CreateClient();

            //var reponseMessage = await client.GetAsync("https://localhost:7000/api/Products/ProductListWithCategoryByCategoryId/66224a3a542696be99bf3bcf");



            //if (reponseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await reponseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            //    return View(values);
            //}

            //return View();
        }
    }

   
}
