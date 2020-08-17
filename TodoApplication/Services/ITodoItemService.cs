using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApplication.Data;

namespace TodoApplication.Services
{
    public interface ITodoItemService
    {
       Task<IEnumerable<TodoItem>> GetInCompleteItemsAsync();
       Task<bool> AddItemAsync(TodoItem item);

    }
}
