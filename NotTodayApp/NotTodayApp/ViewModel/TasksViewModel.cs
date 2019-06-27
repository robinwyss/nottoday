using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using NotTodayApp.Model;

namespace NotTodayApp.ViewModel {
  class TasksViewModel: INotifyPropertyChanged {
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

    public void OnPropertyChanged(string propertyName) {
      PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
