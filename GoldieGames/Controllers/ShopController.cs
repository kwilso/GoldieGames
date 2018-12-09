using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GoldieGames.Models;
using GoldieGames.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GoldieGames.Controllers
{
    public class ShopController : Controller
    {
        private IBoardGameRepository repository;
        private IOrderRepository orderrepository;
        private Cart cart;

        public ShopController(IBoardGameRepository repo, IOrderRepository otherrepo, Cart cartService)
        {
            repository = repo;
            orderrepository = otherrepo;
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

        public ViewResult Order() => View(new Order());

        [HttpPost]
        public IActionResult Order(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                orderrepository.SaveOrder(order);
                return RedirectToAction(nameof(OrderCompleted));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult OrderCompleted()
        {
            cart.Clear();
            return View();
        }
        [Authorize]
        public ViewResult OrderProcess() =>
        View(orderrepository.Orders.Where(o => !o.Shipped));
        [HttpPost]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = orderrepository.Orders
            .FirstOrDefault(o => o.OrderID == orderID);
            if (order != null)
            {
                order.Shipped = true;
                orderrepository.SaveOrder(order);
            }
            return RedirectToAction(nameof(OrderProcess));
        }



    }
}