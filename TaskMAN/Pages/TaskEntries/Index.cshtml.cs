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
    public class IndexModel : PageModel
    {
        private readonly TaskMAN.Data.TaskMANContext _context;

        public IndexModel(TaskMAN.Data.TaskMANContext context)
        {
            _context = context;
        }

        public IList<TaskEntry> TaskEntry { get;set; }

        public async Task OnGetAsync()
        {
            TaskEntry = await _context.TaskEntry.ToListAsync();
        }
    }
}
