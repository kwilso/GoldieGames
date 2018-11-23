using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GoldieGames.Controllers
{
    public class UserController : Controller
    {
        public IActionResult User()
        {
            return View();
        }
        public IActionResult NewAccount()
        {
            return View();
        }

    }
}