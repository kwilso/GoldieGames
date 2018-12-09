using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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
