using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoListWebApp.Models;
using ToDoListWebApp.Services;
using ToDoListWebApp.Ui.Mvc.Models;

namespace ToDoListWebApp.Ui.Mvc.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ToDoServices _ToDoServices;

        public ToDoController(ToDoServices ToDoServices, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _ToDoServices = ToDoServices;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var ToDoItems = _ToDoServices.GetToDoFromUser(user.Id);
                return View(ToDoItems);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var toDoItem = new ToDoItem()
                {
                    UserId = user.Id,
                    Title = model.Title,
                    Description = model.Description,
                    CreatedAt = DateTime.Now
                };

                _ToDoServices.AddToDoItem(toDoItem);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Complete(int id)
        {
            _ToDoServices.CompleteToDoItem(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _ToDoServices.DeleteToDoItem(id);
            return RedirectToAction("Index");
        }

    }
}
