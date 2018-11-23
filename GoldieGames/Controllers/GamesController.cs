using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoldieGames.Models;

namespace GoldieGames.Controllers
{
    public class GamesController : Controller
    {
        private IBoardGameRepository repository;

        public GamesController(IBoardGameRepository repo)
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
        [HttpGet]
        public ViewResult AddItem() => View();
        

        [HttpPost]
        public IActionResult AddItem(BoardGame obj)
        {
            repository.AddBoardGame(obj);
            return View("Added", obj);
        }

        public IActionResult Item()
        {
            return View();
        }
        
        public IActionResult ItemsList()
        {
            return View(repository.NewBoardGame);
        }

        
    }
}