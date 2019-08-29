using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using NotToday.Storage;
using NotToday.Storage.Model;
using NotTodayApp.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace NotTodayApp.ViewModel {
  public class TasksViewModel : BaseViewModel {
    private ObservableCollection<Task> _tasks;
    private ITaskRepository taskRepository => DependencyService.Get<ITaskRepository>();

    public ObservableCollection<Task> Tasks {
      get => _tasks;
      set {
        _tasks = value;
        OnPropertyChanged();
      }
    }

    //public TasksViewModel() {
    //  taskRepository = DependencyService.Resolve<ITaskRepository>();
    //}

    internal void LoadTasks(Time time) {
      var tasks = GetTasks(time);
      Tasks = new ObservableCollection<Task>(tasks);
    }

    private IEnumerable<Task> GetTasks(Time time) {
      switch (time) {
        case Time.Today:
          return taskRepository.GetTodaysTasks();
        case Time.Future:
          return taskRepository.GetFutureTasks();
        case Time.Overdue:
          return taskRepository.GetPastTasks();
        default:
          return taskRepository.GetAllTasks();
      }
    }
  }

  enum Time {
    Today,
    Future,
    Overdue
  }
}
