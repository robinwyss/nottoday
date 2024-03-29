﻿using System;
using System.Windows.Input;
using NotToday.Storage;
using NotToday.Storage.Model;
using NotTodayApp.Services;
using NotTodayApp.Utils;
using Xamarin.Forms;

namespace NotTodayApp.ViewModel {
  public class TaskEditViewModel: BaseViewModel {
    private ITaskRepository taskRepository => DependencyService.Resolve<ITaskRepository>();
    private INavigationService navigationService => DependencyService.Resolve<INavigationService>();

    private string title;
    private string description;
    private DateTime dueDate;
    private Task task;

    public Command SaveCommand { get; private set; }

    public void Init( string taskId ) {
      var id = Guid.Parse( taskId );
      task = taskRepository.GetTask( id );
      Title = task.Title;
      Description = task.Description;
      DueDate = task.DueDate;
    }

    public TaskEditViewModel() {
      SaveCommand = new Command( () => {
        task.Title = Title;
        task.Description = Description;
        task.DueDate = DueDate;
        taskRepository.CreateOrUpdateTask( task );
        navigationService.NavigateBackAsync();
      }, () => !string.IsNullOrEmpty( Title ) );
    }

    public string Title {
      get => title; set {
        title = value;
        OnPropertyChanged();
        SaveCommand.ChangeCanExecute();
      }
    }
    public string Description {
      get => description; set {
        description = value;
        OnPropertyChanged();
      }
    }
    public DateTime DueDate {
      get => dueDate; set {
        dueDate = value;
        OnPropertyChanged();
      }
    }


  }
}
