using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Dal;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _db;
        public TasksController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<TaskModel> tasks = await _db.Tasks.ToListAsync();
            ViewBag.Count = 1;
            return View(tasks);
        }
    }
}
