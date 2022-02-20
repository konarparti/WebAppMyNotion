﻿using System;
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
                return RedirectToAction(nameof(Index));
            }
            return View(interest);
        }
    }
}
