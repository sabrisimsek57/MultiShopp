﻿using Microsoft.AspNetCore.Authentication;
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
        public async Task< IActionResult> Index(SıgnUpDto sıgnUpDto)
        {
           
           await ıdentityService.SıgnIn(sıgnUpDto);
            return RedirectToAction("Index", "User");


        }
        [HttpGet]
        public IActionResult Indexx()
        {
            return View();
        }

      

   
        public async Task< IActionResult> SıgnUp(SıgnUpDto sıgnUpDto)
        {
            sıgnUpDto.Username = "Can22";
            sıgnUpDto.Password = "111111aA*";
            await ıdentityService.SıgnIn(sıgnUpDto);
            return RedirectToAction("Index", "User");

            
        }
    }
}
