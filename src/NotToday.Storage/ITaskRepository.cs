using System;
using System.Collections.Generic;
using System.Text;
using NotToday.Storage.Model;

namespace NotToday.Storage {
  public interface ITaskRepository {
    IEnumerable<Task> GetAllTasks();

    IEnumerable<Task> GetTodaysTasks();

    IEnumerable<Task> GetFutureTasks();

    IEnumerable<Task> GetPastTasks();

    Task GetTask( Guid taskId );

    void DeleteTask( Guid taskId );

    Guid CreateOrUpdateTask( Task task );
  }
}
