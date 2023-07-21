using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Findpropertymain.Models;

namespace Findpropertymain.Controllers
{
    public class OwnerController : Controller
    {
        private readonly propertyslnContext _context;

        public OwnerController(propertyslnContext context)
        {
            _context = context;
        }

        // GET: Owner
        public async Task<IActionResult> Index()
        {
            var propertyslnContext = _context.Properties.Include(g => g.Owner).Include(g => g.PropType);
            return View(await propertyslnContext.ToListAsync());
        }

        // GET: Owner/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Properties
                .Include(g => g.Owner)
                .Include(g => g.PropType)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // GET: Owner/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Users, "UserId", "UserEmailId");
            ViewData["PropTypeId"] = new SelectList(_context.PropertyTypes, "PropTypeId", "TypeNmae");
            return View();
        }

        // POST: Owner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyId,PropertyName,BhkType,FloorNo,TotalFloorNo,PropertyAge,PropertyFacing,City,Locality,StreetArea,PropertyPrice,Images,PropTypeId,OwnerId")] Property @property)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@property);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Users, "UserId", "UserEmailId", @property.OwnerId);
            ViewData["PropTypeId"] = new SelectList(_context.PropertyTypes, "PropTypeId", "TypeNmae", @property.PropTypeId);
            return View(@property);
        }

        // GET: Owner/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Properties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Users, "UserId", "UserEmailId", @property.OwnerId);
            ViewData["PropTypeId"] = new SelectList(_context.PropertyTypes, "PropTypeId", "TypeNmae", @property.PropTypeId);
            return View(@property);
        }

        // POST: Owner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("PropertyId,PropertyName,BhkType,FloorNo,TotalFloorNo,PropertyAge,PropertyFacing,City,Locality,StreetArea,PropertyPrice,Images,PropTypeId,OwnerId")] Property @property)
        {
            if (id != @property.PropertyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(@property.PropertyId))
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
            ViewData["OwnerId"] = new SelectList(_context.Users, "UserId", "UserEmailId", @property.OwnerId);
            ViewData["PropTypeId"] = new SelectList(_context.PropertyTypes, "PropTypeId", "TypeNmae", @property.PropTypeId);
            return View(@property);
        }

        // GET: Owner/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Properties
                .Include(g => g.Owner)
                .Include(g => g.PropType)
                .FirstOrDefaultAsync(m => m.PropertyId == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var @property = await _context.Properties.FindAsync(id);
            _context.Properties.Remove(@property);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(short id)
        {
            return _context.Properties.Any(e => e.PropertyId == id);
        }
    }
}
