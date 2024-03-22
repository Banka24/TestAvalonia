using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDoList.DataModel;

namespace ToDoList.ViewModels;

public class ToDoListViewModel(IEnumerable<ToDoItem> items) : ViewModelBase
{
    public ObservableCollection<ToDoItem> ListItems { get; } = new(items);
}