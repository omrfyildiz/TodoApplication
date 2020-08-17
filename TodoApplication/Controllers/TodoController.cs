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
        private readonly ITodoItemService _service;
        private readonly IKodluyoruzLogger _logger;

        public TodoController(ITodoItemService service, IKodluyoruzLogger logger)
        {
            _service = service;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            // Get to-do items from database

            //IEnumerable<TodoItem> items = service.GetInCompleteItemsAsync().Result;
            IEnumerable<TodoItem> items = await _service.GetInCompleteItemsAsync();

            // Put items into a model
            TodoViewModel vm = new TodoViewModel();
            vm.Items = items;
            // Render view using the model

            ViewBag.Title = "Yapılacaklar Listesini Yönet";

            // Modeli görüntüye ekle ve sayfayı göster.
            //logger.Write();
            return View(vm);
        }

        public async Task<IActionResult> AddItem(TodoItem item)
        {
            var result = await _service.AddItemAsync(item);

            return View();
        }
    }
}
