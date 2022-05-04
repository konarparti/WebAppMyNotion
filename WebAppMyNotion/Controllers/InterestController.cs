using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMyNotion.Models;

namespace WebAppMyNotion.Controllers
{
    public class InterestController : Controller
    {
        private readonly ApplicationDbContext _context;
        public InterestController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Interests.ToListAsync());
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Interest interest)
        {
            if (ModelState.IsValid)
            {
                await _context.Interests.AddAsync(interest);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Запись успешно добавлена";
                return RedirectToAction(nameof(Index));
            }
            return View(interest);
        }

        //Get
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var interestFromDb = await _context.Interests.FirstOrDefaultAsync(i => i.Id == id);
            if (interestFromDb == null)
            {
                return NotFound();
            }

            return View(interestFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Interest interest)
        {
            if (ModelState.IsValid)
            {
                _context.Interests.Update(interest);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Запись успешно изменена";
                return RedirectToAction(nameof(Index));
            }
            return View(interest);
        }

        //Get
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var interestFromDb = await _context.Interests.FirstOrDefaultAsync(i => i.Id == id);
            if (interestFromDb == null)
            {
                return NotFound();
            }

            return View(interestFromDb);
        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var interestFromDb = _context.Interests.FirstOrDefault(i => i.Id == id);
            if (interestFromDb == null)
            {
                return NotFound();
            }
            _context.Interests.Remove(interestFromDb);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Запись успешно удалена";
            return RedirectToAction(nameof(Index));
        }

        //Get
        [HttpGet]
        public async Task<IActionResult> ShowMore(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var interestFromDb = await _context.Interests.FirstOrDefaultAsync(i => i.Id == id);
            if (interestFromDb == null)
            {
                return NotFound();
            }
            return View(interestFromDb);
        }
    }
}
