using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using System.Diagnostics;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TodoDatabase _database;

        public HomeController(ILogger<HomeController> logger, TodoDatabase database)
        {
            _logger = logger;
            _database = database;
        }

        public IActionResult Create(string Name, string description)
        {
            TodoApplication todoApplication = new TodoApplication();
            todoApplication.Name = Name;
            todoApplication.Description = description;
            _database.Applications.Add(todoApplication);
            _database.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public List<TodoApplication> ShowData()
        {
            var _showData = _database.Applications.ToList();
            return _showData;
        }
        public IActionResult Index()
        {
            var _showData = _database.Applications.ToList();
            return View(_showData);
        }
        public IActionResult Delete(int id)
        {
            var DelData = _database.Applications.FirstOrDefault(x => x.Id == id);
            if (DelData != null)
            {
                _database.Applications.Remove(DelData);
                _database.SaveChanges();
            }
            else
            {
                Console.WriteLine("no data found");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Update(int id, string Name, string Description)
        {
            var UpdateData = _database.Applications.FirstOrDefault(x => x.Id == id);
            if (UpdateData != null)
            {
                UpdateData.Name = Name;
                UpdateData.Description = Description;
                _database.Update(UpdateData);
                _database.SaveChanges();
            }
            else { Console.WriteLine("no data found"); }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult CreateData()
        {
            return View();
        }

        public IActionResult Deleted(int id)
        {
            var ShowValue = _database.Applications.FirstOrDefault(x => x.Id == id);
            if (ShowValue == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(ShowValue);
            }
        }
        public IActionResult Updated(int id)
        {
            var updateData = _database.Applications.FirstOrDefault(x => x.Id == id);
            if (updateData != null)
            {
                return View(updateData);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
