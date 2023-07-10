using CinemaApplication.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace CinemaApplication.Web.Models.Identity
{
    public class CinemaTicketUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ShoppingCart UserCart { get; set; }
    }
}
