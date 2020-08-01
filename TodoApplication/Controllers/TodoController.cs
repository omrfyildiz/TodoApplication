using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApplication.Data;
using TodoApplication.Models;
using TodoApplication.Services;
using TodoApplication.Utilities.Loggers;

namespace TodoApplication.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService service;
        private readonly IKodluyoruzLogger logger;

        public TodoController(ITodoItemService _service, IKodluyoruzLogger _logger)
        {
            service = _service;
            logger = _logger;
        }
        public async Task<IActionResult> IndexAsync()
        {
            // Get to-do items from database

            //IEnumerable<TodoItem> items = service.GetInCompleteItemsAsync().Result;
            IEnumerable<TodoItem> items = await service.GetInCompleteItemsAsync();

            // Put items into a model
            TodoViewModel vm = new TodoViewModel
            {
                Items = items
            };
            // Render view using the model

            ViewBag.Title = "Yapılacaklar Listesini Yönet";

            // Render view using the model
            //logger.Write();
            return View(vm);
        }
    }
}
