using System;
using System.Collections.Generic;
using System.Text;
using NotToday.Storage;
using NotToday.Storage.Model;
using NotTodayApp.Services;
using NotTodayApp.Utils;
using Xamarin.Forms;

namespace NotTodayApp.ViewModel {
  public class TaskDetailViewModel : BaseViewModel {
    private ITaskRepository taskRepository => DependencyService.Resolve<ITaskRepository>();
    private INavigationService navigationService => DependencyService.Get<INavigationService>();
    private Task task;

    public Task Task {
      get => task; set {
        task = value;
        OnPropertyChanged();
      }
    }

    public void LoadTask(string taskId) {
      var taskGuid = Guid.Parse(taskId);
      Task = taskRepository.GetTask(taskGuid);
    }
  }
}
