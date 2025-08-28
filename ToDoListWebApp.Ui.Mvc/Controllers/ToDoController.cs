using Microsoft.AspNetCore.Mvc;

namespace ToDoListWebApp.Ui.Mvc.Controllers
{
    public class ToDoController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            ;
        }
    }
}
