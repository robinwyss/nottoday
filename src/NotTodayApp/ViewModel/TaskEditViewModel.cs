using System;
using System.Windows.Input;
using NotToday.Storage;
using NotToday.Storage.Model;
using NotTodayApp.Utils;
using Xamarin.Forms;

namespace NotTodayApp.ViewModel {
  public class TaskEditViewModel : BaseViewModel {
    private string title;
    private string description;
    private DateTime dueDate = DateTime.Today.AddDays(1);

    public Command SaveCommand { get; set; }

    public TaskEditViewModel() {
      var taskRepository = DependencyService.Resolve<ITaskRepository>();
      SaveCommand = new Command(() => {
        var task = new Task(Title, Description, DueDate);
        taskRepository.CreateOrUpdateTask(task);
      }, () => !string.IsNullOrEmpty(Title));
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
