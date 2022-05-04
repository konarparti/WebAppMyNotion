using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppMyNotion.Models.ViewComponents
{
    public class NotesListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public NotesListViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Default", _context.Notes.ToList()));
        }
    }
}
