using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldieGames.Models
{
    public class BoardGameRepository : IBoardGameRepository
    {

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

        public List<BoardGame> boardgames = new List<BoardGame>();
        public IEnumerable<BoardGame> NewBoardGame
        {
            get
            {
                return boardgames;
            }
        }

        public void AddBoardGame(BoardGame boardgame)
        {
            boardgames.Add(boardgame);
        }

    }
}
