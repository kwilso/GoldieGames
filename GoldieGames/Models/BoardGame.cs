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
        [Required(ErrorMessage = "Please enter a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a Seller")]
        public string Seller { get; set; }
        [Required(ErrorMessage = "Please enter a Genre")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Please enter a Price")]
        public decimal Price { get; set; }
    }
}
