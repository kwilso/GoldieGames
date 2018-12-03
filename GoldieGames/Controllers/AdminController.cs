﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoldieGames.Models;

namespace GoldieGames.Controllers
{
    public class AdminController : Controller
    {
        private IBoardGameRepository repository;

        public AdminController(IBoardGameRepository repo)
        {
            repository = repo;
        }

        public ViewResult AddItem() => View();


        [HttpPost]
        public IActionResult AddItem(BoardGame obj)
        {
            repository.AddBoardGame(obj);
            return View("Added", obj);
        }

        //Edit Action
        public ViewResult EditBoardGame(int BoardGameID) =>
        View(repository.BoardGames
        .FirstOrDefault(p => p.BoardGameID == BoardGameID));

        [HttpPost]
        public IActionResult EditBoardGame(BoardGame games)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBoardGame(games);
                TempData["message"] = $"{games.Title} has been saved";
                return View("EditCompleted");
            }
            else
            {
                // there is something wrong with the data values
                return View(games);
            }
        }

        [HttpPost]
        public IActionResult RemoveBoardGame(int BoardGameID)
        {
            BoardGame deletedProduct = repository.RemoveBoardGame(BoardGameID);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Title} was deleted";
            }
            return View("GameDeleted");
        }
    }
}