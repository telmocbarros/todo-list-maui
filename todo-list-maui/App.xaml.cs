using todo_list_maui.Services;
using todo_list_maui.View_Model;
using todo_list_maui.Views;

namespace todo_list_maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddScoped<ITodoService, TodoService>();

            var app = builder.Build();
            app.Services.GetService<TodoService>();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}