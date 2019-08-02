using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using NotTodayApp.Model;
using NotTodayApp.Utils;
using Xamarin.Forms;

namespace NotTodayApp.ViewModel {
  public class TasksViewModel: BaseViewModel {
    private ObservableCollection<Task> _tasks;
    public ObservableCollection<Task> Tasks {
      get => _tasks;
      set {
        _tasks = value;
        OnPropertyChanged( "Tasks" );
      }
    }

    public TasksViewModel() {
      _tasks = new ObservableCollection<Task>();
      _tasks.Add( new Task( "Test", "Test task to do today", DateTime.Now ) );
    }

  }
}
