using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GoldieGames.Models
{
    public class EFBoardGameRepository : IBoardGameRepository
    {
        private ApplicationDbContext context;

        public EFBoardGameRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<BoardGame> BoardGames => context.BoardGames;

        public void AddBoardGame(BoardGame boardgame)
        {
            context.BoardGames.Add(boardgame);
            context.SaveChanges();
        }

        public void SaveBoardGame(BoardGame games)
        {
             if (games.BoardGameID == 0)
             {
                 context.BoardGames.Add(games);
             }
             else
             {
                 BoardGame dbEntry = context.BoardGames
                 .FirstOrDefault(p => p.BoardGameID == games.BoardGameID);
                 if (dbEntry != null)
                 {
                     dbEntry.Title = games.Title;
                     dbEntry.Seller = games.Seller;
                     dbEntry.Genre = games.Genre;
                     dbEntry.Price = games.Price;
                 }
             }
          
            context.SaveChanges();
        }

        public BoardGame RemoveBoardGame(int BoardGameID)
        {
            BoardGame dbEntry = context.BoardGames
            .FirstOrDefault(p => p.BoardGameID == BoardGameID);
            if (dbEntry != null)
            {
                context.BoardGames.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
