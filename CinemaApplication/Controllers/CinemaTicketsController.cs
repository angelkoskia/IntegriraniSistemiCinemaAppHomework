using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaApplication.Data;
using CinemaApplication.Models.Domain;

namespace CinemaApplication.Web.Controllers
{
    public class CinemaTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CinemaTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CinemaTickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets.ToListAsync());
        }

        // GET: CinemaTickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaTicket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaTicket == null)
            {
                return NotFound();
            }

            return View(cinemaTicket);
        }

        // GET: CinemaTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CinemaTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TitleOfMovie,Genre,Image,Valid,Price,Quantity")] CinemaTicket cinemaTicket)
        {
            if (ModelState.IsValid)
            {
                cinemaTicket.Id = Guid.NewGuid();
                _context.Add(cinemaTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinemaTicket);
        }

        // GET: CinemaTickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaTicket = await _context.Tickets.FindAsync(id);
            if (cinemaTicket == null)
            {
                return NotFound();
            }
            return View(cinemaTicket);
        }

        // POST: CinemaTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TitleOfMovie,Genre,Image,Valid,Price,Quantity")] CinemaTicket cinemaTicket)
        {
            if (id != cinemaTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinemaTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinemaTicketExists(cinemaTicket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cinemaTicket);
        }

        // GET: CinemaTickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinemaTicket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinemaTicket == null)
            {
                return NotFound();
            }

            return View(cinemaTicket);
        }

        // POST: CinemaTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cinemaTicket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(cinemaTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinemaTicketExists(Guid id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
