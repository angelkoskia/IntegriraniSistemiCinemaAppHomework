using CinemaApplication.Web.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApplication.Models.Domain
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public string OwnerId { get; set; }
        public CinemaTicketUser Owner { get; set; }
        public virtual ICollection<TicketsInShoppingCart> TicketsInShoppingCart { get; set; }

    }
}
