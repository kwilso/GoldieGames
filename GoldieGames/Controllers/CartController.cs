﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GoldieGames.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Carts()
        {
            return View();
        }

        //public RedirectToActionResult AddToCart()
       // {
          //  return;
        //{
    }
}