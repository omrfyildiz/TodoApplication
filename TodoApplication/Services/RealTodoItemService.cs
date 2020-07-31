﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApplication.Models;

namespace TodoApplication.Services
{
    public class RealTodoItemService : ITodoItemService
    {
        public Task<IEnumerable<TodoItem>> GetInCompleteItemsAsync()
        {
            IEnumerable<TodoItem> items = new[]
            {
                new TodoItem
                {
                    Title = "test",
                    DueAt = DateTimeOffset.Now.AddDays(1)
                },
                new TodoItem
                {
                    Title = "Test2",
                    DueAt = DateTimeOffset.Now.AddDays(2)
                }
            };

            return Task.FromResult(items);
        }
    }
}
