using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GoldieGames.Models;
using GoldieGames.Models.ViewModels;

namespace GoldieGames.Controllers
{
    public class ShopController : Controller
    {
        private IBoardGameRepository repository;
        private IOrderRepository otherrepository;
        private Cart cart;

        public ShopController(IBoardGameRepository repo, IOrderRepository otherrepo, Cart cartService)
        {
            repository = repo;
            otherrepository = otherrepo;
            cart = cartService;
        }

        public ViewResult Cart(string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult PutInCart(int boardgameId, string returnUrl)
        {
            BoardGame boardGame = repository.BoardGames
                .FirstOrDefault(g => g.BoardGameID == boardgameId);
            if (boardGame != null)
            {
                cart.AddBoardGame(boardGame, 1);
            }
            return RedirectToAction("Cart", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int boardgameId, string returnUrl)
        {
            BoardGame boardGame = repository.BoardGames
                   .FirstOrDefault(g => g.BoardGameID == boardgameId);
            if (boardGame != null)
            {
                cart.RemoveBoardGame(boardGame);
            }
            return RedirectToAction("Cart", new { returnUrl });
        }
        
        public IActionResult Order()
        {
            return View();
        }
    }
}