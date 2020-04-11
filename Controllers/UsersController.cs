using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventOrganizer.Data;
using EventOrganizer.Models;
using EventOrganizer.Utilities;

namespace EventOrganizer.Controllers
{
    public class UsersController : Controller
    {
        private readonly EventOrganizerDbContext _context;

        public UsersController(EventOrganizerDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var eventOrganizerDbContext = _context.User.Include(u => u.Organizer).Include(u => u.Role);
            return View(await eventOrganizerDbContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.Organizer)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["OrganizerId"] = new SelectList(_context.Organizer, "Id", "Id");
            ViewData["RoleId"] = new SelectList(_context.Role, "Id", "Id");
            ViewData["OrganizerName"] = new SelectList(_context.Organizer.Select(x => x.Name).ToList());
            ViewData["RoleName"] = new SelectList(_context.Role.Select(x => x.Name).ToList());
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleId,OrganizerId,Name,Username,Email,Password,Avatar,Gender,PhoneNumber,Address,JoinDate,LastLogin,IsActive,CreatedAt,UpdatedAt")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                user.Password = AuthHelper.EncryptPassword(user.Password);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizerId"] = new SelectList(_context.Organizer, "Id", "Id", user.OrganizerId);
            ViewData["RoleId"] = new SelectList(_context.Role, "Id", "Id", user.RoleId);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["OrganizerId"] = new SelectList(_context.Organizer, "Id", "Id", user.OrganizerId);
            ViewData["RoleId"] = new SelectList(_context.Role, "Id", "Id", user.RoleId);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,RoleId,OrganizerId,Name,Username,Email,Password,Avatar,Gender,PhoneNumber,Address,JoinDate,LastLogin,IsActive,CreatedAt,UpdatedAt")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["OrganizerId"] = new SelectList(_context.Organizer, "Id", "Id", user.OrganizerId);
            ViewData["RoleId"] = new SelectList(_context.Role, "Id", "Id", user.RoleId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.Organizer)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(Guid id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
