using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskMAN.Data;
using TaskMAN.Models;

namespace TaskMAN.Pages.TaskEntries
{
    public class EditModel : PageModel
    {
        private readonly TaskMAN.Data.TaskMANContext _context;

        public EditModel(TaskMAN.Data.TaskMANContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TaskEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskEntryExists(TaskEntry.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TaskEntryExists(int id)
        {
            return _context.TaskEntry.Any(e => e.ID == id);
        }
    }
}
