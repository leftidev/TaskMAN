using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskMAN.Data;
using TaskMAN.Models;

namespace TaskMAN.Pages.TaskEntries
{
    public class CreateModel : PageModel
    {
        private readonly TaskMAN.Data.TaskMANContext _context;

        public CreateModel(TaskMAN.Data.TaskMANContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TaskEntry TaskEntry { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TaskEntry.Add(TaskEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
