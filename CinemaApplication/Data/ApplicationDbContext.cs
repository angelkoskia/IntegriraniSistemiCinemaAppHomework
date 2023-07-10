using CinemaApplication.Models.Domain;
using CinemaApplication.Web.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CinemaTicket> Tickets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TicketsInShoppingCart> TicketsInShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CinemaTicket>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<TicketsInShoppingCart>()
                .HasKey(z => new { z.CinemaTicketId, z.ShoppingCartId });

            builder.Entity<TicketsInShoppingCart>()
                .HasOne(z => z.CinemaTicket)
                .WithMany(z => z.TicketsInShoppingCart)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<TicketsInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.TicketsInShoppingCart)
                .HasForeignKey(z => z.CinemaTicketId);

            builder.Entity<ShoppingCart>()
                .HasOne<CinemaTicketUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);
        }
    }
}
