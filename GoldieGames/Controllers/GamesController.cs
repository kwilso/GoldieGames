﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult User()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Item(int boardgameId)
        {
           BoardGame boardgame = repository.BoardGames
                .FirstOrDefault(g => g.BoardGameID == boardgameId);
            return View("Item", boardgame);
        }

        

        [HttpGet]
        public ViewResult ItemsList()
        {
            return View(repository.BoardGames);
        }

       

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}