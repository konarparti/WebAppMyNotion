using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        
        #region Edit

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

        #endregion

        #region Create

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        public void AddNewNote([FromBody] object req)
        {
            var obj = new
            {
                Name = "",
                Content = "",
                Links = new List<string>(),
                DateAdded = DateTime.Now,
            };
            var temp = JsonConvert.DeserializeAnonymousType(req.ToString(), obj);
            var note = new Note
            {
                Name = temp.Name,
                Content = temp.Content,
                Links = JsonConvert.SerializeObject(temp.Links),
                DateAdded = temp.DateAdded
            };
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        #endregion

        #region Delete

        //Get
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var noteFromDb = _context.Notes.FirstOrDefault(i => i.Id == id);
            if (noteFromDb == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(noteFromDb);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Запись успешно удалена";
            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}
