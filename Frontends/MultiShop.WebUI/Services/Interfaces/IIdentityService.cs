using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {       
        Task<bool> SıgnIn(SıgnUpDto sıgnUpDto);

        Task<bool> GetRefreshToken();
    }
}
