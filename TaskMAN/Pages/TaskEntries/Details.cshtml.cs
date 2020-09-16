using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskMAN.Data;
using TaskMAN.Models;

namespace TaskMAN.Pages.TaskEntries
{
    public class DetailsModel : PageModel
    {
        private readonly TaskMAN.Data.TaskMANContext _context;

        public DetailsModel(TaskMAN.Data.TaskMANContext context)
        {
            _context = context;
        }

        public TaskEntry TaskEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskEntry = await _context.TaskEntry.FirstOrDefaultAsync(m => m.ID == id);

            if (TaskEntry == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
