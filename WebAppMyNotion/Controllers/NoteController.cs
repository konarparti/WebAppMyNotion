using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View(_context.Notes);
        }

        //Get
        [HttpGet]
        public IActionResult ShowMore(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var noteFromDb = _context.Notes.FirstOrDefault(i => i.Id == id);
            if (noteFromDb == null)
            {
                return NotFound();
            }
            return View(noteFromDb);
        }
    }
}
