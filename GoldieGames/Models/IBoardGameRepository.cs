using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldieGames.Models
{
    public interface IBoardGameRepository
    {
        IEnumerable<BoardGame> BoardGames { get; }
        void AddBoardGame(BoardGame game);
    }
}
