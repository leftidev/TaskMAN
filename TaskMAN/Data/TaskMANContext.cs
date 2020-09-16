using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskMAN.Models;

namespace TaskMAN.Data
{
    public class TaskMANContext : DbContext
    {
        public TaskMANContext (DbContextOptions<TaskMANContext> options)
            : base(options)
        {
        }

        public DbSet<TaskMAN.Models.TaskEntry> TaskEntry { get; set; }
    }
}
