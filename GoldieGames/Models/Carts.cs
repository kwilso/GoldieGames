using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldieGames.Models
{
    public class Carts
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(BoardGame boardgame, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.BoardGames.BoardGameID == boardgame.BoardGameID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    BoardGames = boardgame,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(BoardGame boardgame) =>
            lineCollection.RemoveAll(l => l.BoardGames.BoardGameID == boardgame.BoardGameID);

        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(e => e.BoardGames.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public BoardGame BoardGames { get; set; }
        public int Quantity { get; set; }
    }

}
