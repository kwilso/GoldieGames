using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoldieGames.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddBoardGame(BoardGame boardGame, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.BoardGame.BoardGameID == boardGame.BoardGameID)
                .FirstOrDefault();

            if(line == null)
            {
                lineCollection.Add(new CartLine
                {
                    BoardGame = boardGame,
                    Quantity = quantity
                });
            }

            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveBoardGame(BoardGame boardGame)
            => lineCollection.RemoveAll(g => g.BoardGame.BoardGameID == boardGame.BoardGameID);
        public virtual decimal CalculateTotalPrice()
            => lineCollection.Sum(c => c.BoardGame.Price * c.Quantity);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public BoardGame BoardGame { get; set; }
        public int Quantity { get; set; }
    }
}
