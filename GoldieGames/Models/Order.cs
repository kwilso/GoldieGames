using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;

namespace GoldieGames.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a Zip")]
        public string Zip { get; set; }
        public bool GiftWrap { get; set; }
        public ICollection<CartLine> Lines { get; set; }
        public bool Shipped { get; set; }
    }
}
