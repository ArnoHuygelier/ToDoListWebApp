using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListWebApp.Models;
using ToDoListWebApp.Repository;

namespace ToDoListWebApp.Services
{
    public class ToDoServices
    {
        private readonly ApplicationDbContext _context;

        public ToDoServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ToDoItem> GetToDoFromUser(string userId)
        {
            return _context.ToDoItems.Where(x => x.UserId == userId).ToList();
        }

        public void AddToDoItem(ToDoItem toDoItem)
        {
            _context.ToDoItems.Add(toDoItem);
            _context.SaveChanges();
        }

        public void UpdateToDoItem(ToDoItem toDoItem)
        {
            _context.ToDoItems.Update(toDoItem);
            _context.SaveChanges();
        }

        public void DeleteToDoItem(int id)
        {
            var todoItem = _context.ToDoItems.Find(id);
            _context.ToDoItems.Remove(todoItem);
            _context.SaveChanges();
        }

        public void CompleteToDoItem(int id)
        {
            ToDoItem toDoItem = _context.ToDoItems.Find(id);
            toDoItem.IsCompleted = true;
            _context.ToDoItems.Update(toDoItem);
            _context.SaveChanges();
        }
    }
}
