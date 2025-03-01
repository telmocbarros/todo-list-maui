using Microsoft.Maui.Controls;
using todo_list_maui.Models;
using todo_list_maui.Services;
using todo_list_maui.View_Model;

namespace todo_list_maui.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainVIewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainVIewModel(new TodoService());
            BindingContext = _viewModel; // Set the binding context to the view model. Binding the context of this main page to the mainViewModel. Thus establishing a connection between the view and the view model
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadTodoItemsAsync();
        }

        private async void OnAddTodoClicked(object sender, EventArgs e)
        {
           var  newTodoTitle = NewTodoEntry.Text;
            if (!string.IsNullOrWhiteSpace(newTodoTitle))
            {
                await _viewModel.AddTodoItemAsync(newTodoTitle);
                NewTodoEntry.Text = string.Empty;
            }
        }

        private async void OnTodoItemToggled(object sender, EventArgs e) 
        { 
            if (sender is Switch toggleSwitch && toggleSwitch.BindingContext is TodoItem todoItem)
            {
                await _viewModel.ToggleTodoItemCompletionAsync(todoItem);
            }
        }


    }
}
