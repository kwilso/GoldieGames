using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        /* private List<BoardGame> boardgames = new List<BoardGame>()
         {
             new BoardGame {BoardGameID=1, Name = "GTA V", Price = 49.99M, Description = "This is an open world game" , Category = "Open World"},
             new BoardGame {BoardGameID=2, Name = "Dragonball Xenoverse", Price = 59.99M, Description = "This is mario game", Category = "Action" },
             new BoardGame {BoardGameID=3, Name = "Minecraft", Price = 99.99M, Description = "This is an open world game", Category="Open World" }
         };*/
        /*public BoardGameRepository()
        {
            var initialData = new List<BoardGame>()
            {
                new BoardGame {BoardGameID=1, Name = "Chess", Price = 29.99M, Description = "This is a chess board game made of wood" , Category = "Board"},
            new BoardGame {BoardGameID=2, Name = "UNO", Price = 39.99M, Description = "UNO is a card game you can play with your friends or familiy members!", Category = "Card" },
            new BoardGame {BoardGameID=3, Name = "Monopoly", Price = 49.99M, Description = "Monopoly is a game you compete other players, buy house and take money from players", Category="Dice roll" } };
            
            foreach (BoardGame obj in initialData)
            {
                AddGame(obj);
            }
        }*/

        /*private static List<BoardGame> _BoardGame = new List<BoardGame>(){
            new BoardGame {BoardGameID=1, Title = "Chess", Price=29.99M, Seller="Alams", Genre="Family"},
            new BoardGame {BoardGameID=2, Title = "Monopoly", Price=34.99M, Seller="Hasbro", Genre="Family"},
            new BoardGame {BoardGameID=3, Title = "UNO", Price=45.99M, Seller="Amigo", Genre="Family"},
            };
        public IEnumerable<BoardGame> BoardGames
        {
            get
            {
                return _BoardGame;
            }
        }

        public void AddBoardGame(BoardGame boardgame)
        {
            _BoardGame.Add(boardgame);
        }*/

    }
}
