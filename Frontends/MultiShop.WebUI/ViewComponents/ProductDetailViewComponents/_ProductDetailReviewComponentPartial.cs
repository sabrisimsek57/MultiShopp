using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICommentService _commentService;
        public _ProductDetailReviewComponentPartial(IHttpClientFactory httpClientFactory, ICommentService commentService = null)
        {
            _httpClientFactory = httpClientFactory;
            _commentService = commentService;
        }



        public async  Task<IViewComponentResult> InvokeAsync(string id)
        {


            var values = await _commentService.CommentListByProductId(id);
            return View(values);


            //var client = _httpClientFactory.CreateClient();

            //var reponseMessage = await client.GetAsync("https://localhost:7185/api/Comments/CommentListByProductId/"+id);
            //if (reponseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await reponseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            //    return View(values);
            //}

            //return View();
        }
    }
   
}
