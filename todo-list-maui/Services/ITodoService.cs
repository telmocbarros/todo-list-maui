using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo_list_maui.Models;

namespace todo_list_maui.Services
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetTodoItemsAsync();
        Task<TodoItem?> GetTodoItemAsync(String id);
        Task<TodoItem> AddTodoItemAsync(TodoItem todoItem);
        Task ToggleTodoItemCompletionAsync(TodoItem todoItem);
    }
}
