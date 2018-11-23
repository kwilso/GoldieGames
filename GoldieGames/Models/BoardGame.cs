using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoldieGames.Models
{
    public class BoardGame
    {
        [Key]
        public int BoardGameID { get; set; }
        public string Title { get; set; }
        public string Seller { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
