using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo_list_maui.Models;

namespace todo_list_maui.Services
{
    public class TodoService : ITodoService
    {
        private List<TodoItem> _todoItems;
        public TodoService() {
            _todoItems = new List<TodoItem>{
                new TodoItem { Id = 1, Title = "First item", IsDone = false },
                new TodoItem { Id = 2, Title = "Second item", IsDone = true },
                new TodoItem { Id = 3, Title = "Third item", IsDone = false },
                new TodoItem { Id = 4, Title = "Fourth item", IsDone = true }
            };
        }

        public async Task<TodoItem> AddTodoItemAsync(TodoItem todoItem)
        {
            todoItem.Id = _todoItems.Max(t => t.Id) + 1;
            _todoItems.Add(todoItem);
            return await Task.FromResult(todoItem);
        }

        public async Task<TodoItem?> GetTodoItemAsync(string id)
        {
            ArgumentNullException.ThrowIfNull(id, nameof(id));
            try
            {
                var todoItem = await Task.FromResult(_todoItems.FirstOrDefault(t => t.Id.ToString() == id));
                return todoItem;
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(nameof(id));
            }
            
        }

        public async Task<List<TodoItem>> GetTodoItemsAsync()
        {
            return await Task.FromResult(_todoItems);
        }

        public async Task ToggleTodoItemCompletionAsync(TodoItem todoItem)
        {
            todoItem.IsDone = !todoItem.IsDone;
            await Task.CompletedTask;
        }
    }
}
