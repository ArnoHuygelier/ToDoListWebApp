using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListWebApp.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsCompleted { get; set; }  
        public DateTime CreatedAt { get; set; } 
        public DateTime? CompletedAt { get; set; }


        public string? UserId { get; set; } 
        public required ApplicationUser User { get; set; } 
    }
}
