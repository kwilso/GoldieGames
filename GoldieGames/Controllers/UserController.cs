using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoldieGames.Models;

namespace GoldieGames.Controllers
{
    public class UserController : Controller
    {
        private IBoardGameRepository repository;

        public UserController(IBoardGameRepository repo)
        {
            repository = repo;
        }
        public IActionResult User()
        {
            return View();
        }
        public IActionResult NewAccount()
        {
            return View();
        }
        public IActionResult AddItem()
        {
            return View();
        }
    }
}