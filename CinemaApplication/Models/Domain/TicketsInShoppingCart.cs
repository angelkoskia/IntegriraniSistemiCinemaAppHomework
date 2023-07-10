using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApplication.Models.Domain
{
    public class TicketsInShoppingCart
    {
        public Guid ShoppingCartId { get; set; }
        public CinemaTicket CinemaTicket { get; set; }
        public Guid CinemaTicketId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
