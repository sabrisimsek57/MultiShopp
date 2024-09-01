using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
       
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        
        }
        [Route("Index")]
        public async Task <IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Katagoriler";
            ViewBag.v3 = "Katagori Listesi";
            ViewBag.v0 = "Katagori İşlemleri";
       
            var client = _httpClientFactory.CreateClient();
       
            var reponseMessage = await client.GetAsync("https://localhost:7000/api/Categories");
            if(reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData); 
                return View(values);
            }
            
            return View();
        }
        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {

            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Katagoriler";
            ViewBag.v3 = "Yeni Kategori Girişi";
            ViewBag.v0 = "Katagori İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateCategory")]
        public async Task< IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stirngcontenct = new StringContent(jsondata, Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7000/api/Categories",stirngcontenct);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category",new { area = "Admin" });
            }
            return View();
        }
        string id = "w232";
        [HttpDelete]
        [Route("DeleteCategories/")]
        public async Task <IActionResult> DeleteCategories(string id)
        {
            var client = _httpClientFactory.CreateClient();


            var respınseMessage = await client.DeleteAsync("https://localhost:7000/api/Categories?id=" + id);
            if (respınseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {

            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Katagoriler";
            ViewBag.v3 = "Yeni Kategori Girişi";
            ViewBag.v0 = "Katagori İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var respınseMessage = await client.GetAsync("https://localhost:7000/api/Categories/" + id);
            if(respınseMessage.IsSuccessStatusCode)
            {
                var jsondata = await respınseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsondata);
                return View(values);
            }
            return View();
        }
        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var reponısemessage = await client.PutAsync("https://localhost:7000/api/Categories/", stringContent);
            if(reponısemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
    }
}
