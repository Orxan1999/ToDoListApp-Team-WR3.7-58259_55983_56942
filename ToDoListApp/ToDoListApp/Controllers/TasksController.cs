using Microsoft.AspNetCore.Mvc;

namespace ToDoListApp.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
