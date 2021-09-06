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
    public class SliderItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SliderItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SliderItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.SliderItem.ToListAsync());
        }

        // GET: SliderItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderItem = await _context.SliderItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sliderItem == null)
            {
                return NotFound();
            }

            return View(sliderItem);
        }

        // GET: SliderItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SliderItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImgUrl,Title,Text,Url,SliderGorupId")] SliderItem sliderItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sliderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sliderItem);
        }

        // GET: SliderItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderItem = await _context.SliderItem.FindAsync(id);
            if (sliderItem == null)
            {
                return NotFound();
            }
            return View(sliderItem);
        }

        // POST: SliderItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImgUrl,Title,Text,Url,SliderGorupId")] SliderItem sliderItem)
        {
            if (id != sliderItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sliderItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderItemExists(sliderItem.Id))
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
            return View(sliderItem);
        }

        // GET: SliderItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliderItem = await _context.SliderItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sliderItem == null)
            {
                return NotFound();
            }

            return View(sliderItem);
        }

        // POST: SliderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sliderItem = await _context.SliderItem.FindAsync(id);
            _context.SliderItem.Remove(sliderItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderItemExists(int id)
        {
            return _context.SliderItem.Any(e => e.Id == id);
        }
    }
}
