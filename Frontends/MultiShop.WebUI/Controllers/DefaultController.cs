﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            var user = User.Claims;
            int x;
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Ana Sayfa";
            ViewBag.directory3 = "Ürün Listesi";
            return View();
        }
    }
}
