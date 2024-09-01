using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProdcutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProdcutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(String id)
        {
            ViewBag.v = id;
            return View();
        }
        string productdegeri;
        public IActionResult ProductDetail(string id)
        {
            ViewBag.x = id;
            TempData["ProductId"] = id;
            
            return View();
        }
        
        [HttpGet]
        public PartialViewResult AddComment()
        {
            var productId = TempData["ProductId"] as string; // TempData'dan veriyi alıyoruz
                                                             // ViewData veya ViewBag ile kullanabilirsiniz
            ViewData["ProductId"] = productId;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            var productId = TempData["ProductId"] as string; // TempData'dan veriyi alıyoruz


            createCommentDto.ImageUrl = "test";
            createCommentDto.Rating = 1;
            createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDto.Status = false;
            createCommentDto.ProductId = productId;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7185/api/Comments", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
