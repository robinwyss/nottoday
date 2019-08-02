using System;
using System.Collections.Generic;
using System.Text;

namespace NotToday.Storage {
  public interface ITaskRepository {
    IEnumerable<Task> GetAllTasks();

    Task GetTask( Guid taskId );

    void DelteteTask( Guid taskId );

    Guid CreateOrUpdateTask( Task task );
  }
}
