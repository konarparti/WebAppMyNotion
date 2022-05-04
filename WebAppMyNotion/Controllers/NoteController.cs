using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMyNotion.Models;

namespace WebAppMyNotion.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notes.ToListAsync());
        }

        //Get
        [HttpGet]
        public async Task<IActionResult> ShowMore(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var noteFromDb = await _context.Notes.FirstOrDefaultAsync(i => i.Id == id);
            if (noteFromDb == null)
            {
                return NotFound();
            }
            return View(noteFromDb);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Note note)
        {
            if (ModelState.IsValid)
            {
                await _context.Notes.AddAsync(note);
                await  _context.SaveChangesAsync();
                TempData["Success"] = "Запись успешно добавлена";
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }

        //Get
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var noteFromDb = await _context.Notes.FirstOrDefaultAsync(i => i.Id == id);
            if (noteFromDb == null)
            {
                return NotFound();
            }

            return View(noteFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Update(note);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Запись успешно изменена";
                return RedirectToAction(nameof(Index));
            }
            return View(note);
        }
    }
}
