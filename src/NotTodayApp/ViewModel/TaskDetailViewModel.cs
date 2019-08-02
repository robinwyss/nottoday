using System;
using System.Collections.Generic;
using System.Text;
using NotTodayApp.Model;
using NotTodayApp.Utils;

namespace NotTodayApp.ViewModel {
  public class TaskDetailViewModel: BaseViewModel {

    public Task Task { get; set; }

    public TaskDetailViewModel( Task task ) {
      Task = task;
    }
  }
}
