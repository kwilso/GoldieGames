using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoldieGames.Models;

namespace GoldieGames.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Carts()
        {
            return View();
        }

        //public RedirectToActionResult AddToCart()
        // {
        //  return;
        //}
        public IActionResult Order()
        {
            return View();
        }
    }
}