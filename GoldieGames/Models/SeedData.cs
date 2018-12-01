using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace GoldieGames.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.BoardGames.Any())
            {
                context.BoardGames.AddRange(

            new BoardGame { Title = "Chess", Price = 29.99M, Seller = "Alams", Genre = "Family" },
            new BoardGame { Title = "Monopoly", Price = 34.99M, Seller = "Hasbro", Genre = "Family" },
            new BoardGame { Title = "UNO", Price = 45.99M, Seller = "Amigo", Genre = "Family" },
            new BoardGame { Title = "The Game of Life", Price = 39.99M, Seller = "Hasbro", Genre = "Family" },
            new BoardGame { Title = "Battleship", Price = 25.99M, Seller = "Hasbro", Genre = "Family" },
            new BoardGame { Title = "Fishing Camp The Game", Price = 25.99M, Seller = "Hasbro", Genre = "Party" },
            new BoardGame { Title = "JINX", Price = 25.99M, Seller = "Hasbro", Genre = "Family" },
            new BoardGame { Title = "Dungeon!", Price = 39.99M, Seller = "Wizards of the Coast", Genre = "Party" }
                    );
                context.SaveChanges();
                context.SaveChanges();

            }
        }
    }
}
