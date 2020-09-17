using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskMAN.Models
{
    public class TaskEntry
    {
        // ID is the primary key in the DB
        public int ID { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public TaskEntry()
        {
            this.CreatedDate = DateTime.Now;
        }

    }


}
