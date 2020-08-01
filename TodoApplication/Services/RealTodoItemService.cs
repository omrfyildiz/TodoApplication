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

        public async Task<IEnumerable<TodoItem>> GetInCompleteItemsAsync()
        {
            var items = await _context.TodoList.Where(x => x.IsDone == false).ToArrayAsync();
            
            return items;
        }
    }

}


