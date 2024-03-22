using System.Collections.Generic;
using ToDoList.DataModel;

namespace ToDoList.Services
{
    public static class ToDoListService
    {
        public static IEnumerable<ToDoItem> GetItems() =>
        [
            new ToDoItem { Description = "Walk the dog" },
            new ToDoItem { Description = "Buy some milk" },
            new ToDoItem { Description = "Learn Avalonia", IsChecked = true }
        ];
    }
}
