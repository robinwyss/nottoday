using System;
using System.Collections.Generic;
using System.Text;
using NotToday.Storage;
using NotToday.Storage.Model;
using NotTodayApp.Services;
using NotTodayApp.Utils;
using Xamarin.Forms;

namespace NotTodayApp.ViewModel {
  class CreateTaskViewModel: BaseViewModel {
    private ITaskRepository taskRepository => DependencyService.Resolve<ITaskRepository>();
    private INavigationService navigationService => DependencyService.Resolve<INavigationService>();

    private string title;
    private string description;
    private DateTime dueDate;

    public Command SaveCommand { get; private set; }

    public CreateTaskViewModel() {
      SaveCommand = new Command( () => {
        var task = new Task( Title, Description, DueDate );
        taskRepository.CreateOrUpdateTask( task );
        navigationService.NagivateToAsync( "//today" );
      }, () => !string.IsNullOrEmpty( Title ) );
    }

    public void Init() {
      Title = string.Empty;
      Description = string.Empty;
      DueDate = DateTime.Today.AddDays( 1 );
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
