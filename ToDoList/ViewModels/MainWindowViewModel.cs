using System;
using System.Reactive.Linq;
using ToDoList.Services;
using ReactiveUI;
using ToDoList.DataModel;

namespace ToDoList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;

        public ToDoListViewModel ToDoList { get; }

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public MainWindowViewModel()
        {
            ToDoList = new ToDoListViewModel(ToDoListService.GetItems());
            _contentViewModel = ToDoList;
        }

        public void AddItem()
        {
            var addItemViewModel = new AddItemViewModel();

            addItemViewModel.OkCommand.Merge(addItemViewModel.CancelCommand.Select(_ => (ToDoItem?)null))
                .Take(1)
                .Subscribe(newItem =>
                {
                    ToDoList.ListItems.Add(newItem!);
                    ContentViewModel = ToDoList;
                });

            ContentViewModel = addItemViewModel;
        }

    }
}
