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


        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Create(TaskModel task)
        {
            task.Title = task.Title?.Trim();
            bool isExists = await _db.Tasks.AnyAsync(x => x.Title == task.Title);

            if (isExists)
            {
                ModelState.AddModelError("Title", "There is already task under this title. Please change the title");
                return View(task);
            }

            if (task.Deadline < DateTime.Now)
            {
                ModelState.AddModelError("Deadline", "Deadline can not be earlier than current time");
                return View(task);

            }

            await _db.Tasks.AddAsync(task);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");


        }

    }
}
