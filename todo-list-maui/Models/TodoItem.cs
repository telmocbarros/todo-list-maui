using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_list_maui.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
