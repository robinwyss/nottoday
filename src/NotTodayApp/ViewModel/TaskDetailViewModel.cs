using System;
using System.Collections.Generic;
using System.Text;
using NotToday.Storage;
using NotToday.Storage.Model;
using NotTodayApp.Utils;
using Xamarin.Forms;

namespace NotTodayApp.ViewModel {
  public class TaskDetailViewModel : BaseViewModel {
    private readonly ITaskRepository taskRepository;
    private Task task;

    public Task Task {
      get => task; set {
        task = value;
        OnPropertyChanged();
      }
    }

    public TaskDetailViewModel() {
      taskRepository = DependencyService.Resolve<ITaskRepository>();
    }

    public void LoadTask(string taskId) {
      var taskGuid = Guid.Parse(taskId);
      Task = taskRepository.GetTask(taskGuid);
    }
  }
}
