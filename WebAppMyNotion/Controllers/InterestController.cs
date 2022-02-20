using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View(_context.Interests);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Interest interest)
        {
            if (ModelState.IsValid)
            {
                _context.Interests.Add(interest);
                _context.SaveChanges();
                TempData["Success"] = "Запись успешно добавлена";
                return RedirectToAction(nameof(Index));
            }
            return View(interest);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var interestFromDb = _context.Interests.FirstOrDefault(i => i.Id == id);
            if (interestFromDb == null)
            {
                return NotFound();
            }

            return View(interestFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Interest interest)
        {
            if (ModelState.IsValid)
            {
                _context.Interests.Update(interest);
                _context.SaveChanges();
                TempData["Success"] = "Запись успешно изменена";
                return RedirectToAction(nameof(Index));
            }
            return View(interest);
        }

        //Get
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null or 0)
            {
                return NotFound();
            }

            var interestFromDb = _context.Interests.FirstOrDefault(i => i.Id == id);
            if (interestFromDb == null)
            {
                return NotFound();
            }

            return View(interestFromDb);
        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var interestFromDb = _context.Interests.FirstOrDefault(i => i.Id == id);
            if (interestFromDb == null)
            {
                return NotFound();
            }
            _context.Interests.Remove(interestFromDb);
            _context.SaveChanges();
            TempData["Success"] = "Запись успешно удалена";
            return RedirectToAction(nameof(Index));
        }
    }
}
