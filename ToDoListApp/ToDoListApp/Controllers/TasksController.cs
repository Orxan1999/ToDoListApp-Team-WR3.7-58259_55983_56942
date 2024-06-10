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

        public async Task<IActionResult> Update(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            TaskModel task = await _db.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
            {
                return BadRequest();
            }


            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, TaskModel newTask, bool status)
        {

            if (id == 0)
            {
                return NotFound();
            }

            TaskModel task = await _db.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (task == null)
            {
                return BadRequest();
            }



            if (newTask.Title != task.Title)
            {
                ModelState.AddModelError("Title", "Title can not be changed");

                return View(task);
            }

            task.Description = newTask.Description;
            task.Deadline = newTask.Deadline;
            task.IsCompleted = status;

            if (newTask.Deadline < DateTime.Now && !task.IsCompleted)
            {
                ModelState.AddModelError("Deadline", "Deadline can not be earlier than current time");
                return View(task);

            }

            if (task.IsCompleted == true)
            {
                task.CompletedOn = DateTime.Now;
            }


            await _db.SaveChangesAsync();
            return RedirectToAction("Index");


        }



        public async Task<IActionResult> Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            TaskModel task = await _db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            TaskModel task = await _db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task == null)
            {
                return BadRequest();
            }


            _db.Remove(task);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> TitleAscending()
        {
            List<TaskModel> tasks = await _db.Tasks.OrderBy(x => x.Title).ToListAsync();
            ViewBag.Count = 1;
            return PartialView("_TitleAscendingPartial", tasks);
        }

        public async Task<IActionResult> TitleDescending()
        {
            List<TaskModel> tasks = await _db.Tasks.OrderByDescending(x => x.Title).ToListAsync();
            ViewBag.Count = 1;
            return PartialView("_TitleDescendingPartial", tasks);
        }



    }
}
