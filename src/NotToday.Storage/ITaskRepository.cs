using System;
using System.Collections.Generic;
using System.Text;
using NotToday.Storage.Model;

namespace NotToday.Storage {
  public interface ITaskRepository {
    IEnumerable<Task> GetAllTasks();

    Task GetTask( Guid taskId );

    void DelteteTask( Guid taskId );

    Guid CreateOrUpdateTask( Task task );
  }
}
