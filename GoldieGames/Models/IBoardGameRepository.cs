using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldieGames.Models
{
    public interface IBoardGameRepository
    {
        IQueryable<BoardGame> BoardGames { get; }
        void AddBoardGame(BoardGame game);

        void SaveBoardGame(BoardGame games);

        BoardGame RemoveBoardGame(int BoardGameID);
    }
}
