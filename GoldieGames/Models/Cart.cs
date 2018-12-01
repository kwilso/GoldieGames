using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoldieGames.Models
{
    public class Cart
    {
        public int CartLineID { get; set; }
        public BoardGame BoardGame { get; set; }
        public int Quantity { get; set; }
    }
}
