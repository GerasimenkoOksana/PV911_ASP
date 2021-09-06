using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUserAjax.Data;
using WebUserAjax.Data.Entities.Slider;

namespace WebUserAjax.Controllers.Admin.Sliders
{
    public class SliderGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SliderGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SliderGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.SliderGroup.ToListAsync());
        }

        // GET: SliderGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderGroup = await _context.SliderGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sliderGroup == null)
            {
                return NotFound();
            }

            return View(sliderGroup);
        }

        // GET: SliderGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SliderGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Name")] SliderGroup sliderGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sliderGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sliderGroup);
        }

        // GET: SliderGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderGroup = await _context.SliderGroup.FindAsync(id);
            if (sliderGroup == null)
            {
                return NotFound();
            }
            return View(sliderGroup);
        }

        // POST: SliderGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Name")] SliderGroup sliderGroup)
        {
            if (id != sliderGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sliderGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderGroupExists(sliderGroup.Id))
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
            return View(sliderGroup);
        }

        // GET: SliderGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderGroup = await _context.SliderGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sliderGroup == null)
            {
                return NotFound();
            }

            return View(sliderGroup);
        }

        // POST: SliderGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sliderGroup = await _context.SliderGroup.FindAsync(id);
            _context.SliderGroup.Remove(sliderGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderGroupExists(int id)
        {
            return _context.SliderGroup.Any(e => e.Id == id);
        }
    }
}
