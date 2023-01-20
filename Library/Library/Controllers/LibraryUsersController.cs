using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Controllers
{
    public class LibraryUsersController : Controller
    {
        private readonly LibraryContext _context;

        public LibraryUsersController(LibraryContext context)
        {
            _context = context;
        }

        // GET: LibraryUsers
        public async Task<IActionResult> Index()
        {
              return View(await _context.LibraryUsers.ToListAsync());
        }

        // GET: LibraryUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LibraryUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]ApplicationUser libraryUser)
        {
            if (ModelState.IsValid)
            {
                libraryUser.Id = Guid.NewGuid();
                var user = _context.LibraryUsers.First(u => u.Email == libraryUser.Email);
                if(user != null)
                {                 
                    return Content("該郵箱已被註冊");
                }
                _context.Add(libraryUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libraryUser);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login([FromForm])
        //{

        //}

        // GET: LibraryUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.LibraryUsers == null)
            {
                return NotFound();
            }

            var libraryUser = await _context.LibraryUsers.FindAsync(id);
            if (libraryUser == null)
            {
                return NotFound();
            }
            return View(libraryUser);
        }

        // POST: LibraryUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Email,Secret")] ApplicationUser libraryUser)
        {
            if (id != libraryUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libraryUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryUserExists(libraryUser.Id))
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
            return View(libraryUser);
        }

        // GET: LibraryUsers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.LibraryUsers == null)
            {
                return NotFound();
            }

            var libraryUser = await _context.LibraryUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraryUser == null)
            {
                return NotFound();
            }

            return View(libraryUser);
        }

        // POST: LibraryUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.LibraryUsers == null)
            {
                return Problem("Entity set 'LibraryContext.LibraryUsers'  is null.");
            }
            var libraryUser = await _context.LibraryUsers.FindAsync(id);
            if (libraryUser != null)
            {
                _context.LibraryUsers.Remove(libraryUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryUserExists(Guid id)
        {
          return _context.LibraryUsers.Any(e => e.Id == id);
        }
    }
}
