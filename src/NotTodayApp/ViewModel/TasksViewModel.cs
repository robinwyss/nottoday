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

    internal void LoadTasks() {
      var tasks = taskRepository.GetAllTasks();
      Tasks = new ObservableCollection<Task>(tasks);
    }
  }
}
