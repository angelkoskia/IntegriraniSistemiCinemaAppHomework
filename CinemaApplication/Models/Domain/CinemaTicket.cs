using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApplication.Models.Domain
{
    public class CinemaTicket
    {
        public Guid Id { get; set; }
        [Required]
        public string TitleOfMovie { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public DateTime Valid { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public virtual ICollection<TicketsInShoppingCart> TicketsInShoppingCart { get; set; }


    }
}
