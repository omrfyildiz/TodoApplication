using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApplication.Data;

namespace TodoApplication.Services
{
    public class RealTodoItemService : ITodoItemService
    {
        private readonly TodoDbContext _context;

        //TODO: DbContext bağımlılığını gider.(Is done[çözüldü])
        public RealTodoItemService(TodoDbContext context)
        {
                _context = context;
        }

        public async Task<bool> AddItemAsync(TodoItem item)
        {
            var entity = new TodoItem
            {
                Id = Guid.NewGuid(),
                IsDone = false,
                Title = item.Title,
                DueAt = DateTimeOffset.Now.AddDays(3)
            };

            _context.TodoItem.Add(entity);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<IEnumerable<TodoItem>> GetInCompleteItemsAsync()
        {
            var items = await _context.TodoItem.Where(x => x.IsDone == false).ToListAsync();
            
            return items;
        }

        
    }

}


