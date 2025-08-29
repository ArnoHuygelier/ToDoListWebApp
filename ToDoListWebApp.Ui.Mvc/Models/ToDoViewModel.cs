using System.ComponentModel.DataAnnotations;

namespace ToDoListWebApp.Ui.Mvc.Models
{
    public class ToDoViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        public required string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public required string Description { get; set; }
    }
}
