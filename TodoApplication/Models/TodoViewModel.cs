using System.Collections.Generic;
using TodoApplication.Data;

namespace TodoApplication.Models
{
    public class TodoViewModel
    {
        public IEnumerable<TodoItem> Items { get; set; }
    }
}
