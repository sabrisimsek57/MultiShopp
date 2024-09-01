using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Interfaces;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService loginService;
        private readonly IIdentityService ıdentityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService ıdentityService)
        {
            _httpClientFactory = httpClientFactory;
            this.loginService = loginService;
            this.ıdentityService = ıdentityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(CreateLoginDto createLoginDto)
        {
           
            var client = _httpClientFactory.CreateClient();
            var contect = new StringContent(JsonSerializer.Serialize(createLoginDto), Encoding.UTF8,"Application/json");
            var reponse = await client.PostAsync("http://localhost:5001/api/Logins", contect);
            if(reponse.IsSuccessStatusCode)
            {
                var jsondata = await reponse.Content.ReadAsStringAsync();
                var tokenmodel = JsonSerializer.Deserialize<JwtResponseModel>(jsondata, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });


                if (tokenmodel != null)
                {
                    JwtSecurityTokenHandler hadler = new JwtSecurityTokenHandler();
                    var token = hadler.ReadJwtToken(tokenmodel.Token);
                    var cliems = token.Claims.ToList();

                    if (tokenmodel.Token != null) 
                    {
                        cliems.Add(new Claim("multishoptoken", tokenmodel.Token));
                        var claimsIdentity = new ClaimsIdentity(cliems, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenmodel.ExpireDate,
                            IsPersistent = true
                        };


                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),authProps);
                        var id = loginService.GetUserId;
                        return RedirectToAction("Index","Default");
                    }
                }
            }

            return View();

        }
        [HttpGet]
        public IActionResult Indexx()
        {
            return View();
        }

      

   
        public async Task< IActionResult> SıgnUp(SıgnUpDto sıgnUpDto)
        {
            sıgnUpDto.UserName = "Can22";
            sıgnUpDto.Password = "111111aA*";
            await ıdentityService.SıgnIn(sıgnUpDto);
            return RedirectToAction("Index", "User");

            
        }
    }
}
