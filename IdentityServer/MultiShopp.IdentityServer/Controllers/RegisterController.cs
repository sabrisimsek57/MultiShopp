using IdentityServer4.Hosting.LocalApiAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShopp.IdentityServer.Dtos;
using MultiShopp.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShopp.IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegister)
        {
            var values = new ApplicationUser()
            {
                UserName = userRegister.UserName,
                Email = userRegister.Email,
                Name = userRegister.Name,
                Surname = userRegister.Surname
            };
            var result = await _userManager.CreateAsync(values, userRegister.Password);
            if(result.Succeeded)
            {
                return Ok("kullanıcı başarıyla eklendi");
            }
            else
            {
                return Ok("bir hata oluştu tekrar deneyiniz");
            }

        }
    }
}
