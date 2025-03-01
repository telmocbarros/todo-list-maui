using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo_list_maui.Models;
using todo_list_maui.Services;

namespace todo_list_maui.View_Model
{
    public class MainVIewModel
    {
        private readonly ITodoService _todoService;
        public ObservableCollection<TodoItem> TodoItems { get; } = new ObservableCollection<TodoItem>();
    
        public MainVIewModel(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task LoadTodoItemsAsync()
        {
            var todoItems = await _todoService.GetTodoItemsAsync();
            TodoItems.Clear();
            foreach (var item in todoItems)
            {
                TodoItems.Add(item);
            }
        }

        public async Task AddTodoItemAsync(string title)
        {
            var todoItem = new TodoItem { Title = title };
            await _todoService.AddTodoItemAsync(todoItem);
            TodoItems.Add(todoItem);
        }

        public async Task ToggleTodoItemCompletionAsync(TodoItem todoItem)
        {
            await _todoService.ToggleTodoItemCompletionAsync(todoItem);
        }

        public async Task<TodoItem?> GetTodoItemAsync(string id)
        {
            return await _todoService.GetTodoItemAsync(id);
        }
    }
}
