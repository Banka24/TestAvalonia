﻿using System.Reactive;
using ReactiveUI;
using ToDoList.DataModel;

namespace ToDoList.ViewModels;

public class AddItemViewModel : ViewModelBase
{
    public string _description = string.Empty;

    public ReactiveCommand<Unit, ToDoItem> OkCommand { get; }
    public ReactiveCommand<Unit, Unit> CancelCommand { get; }

    public AddItemViewModel()
    {
        var isValidObservable = this.WhenAnyValue(
            x => x.Description,
            x => !string.IsNullOrWhiteSpace(x));
        OkCommand = ReactiveCommand.Create(() => new ToDoItem { Description = Description }, isValidObservable);
        CancelCommand = ReactiveCommand.Create(() => { });
    }

    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }
}