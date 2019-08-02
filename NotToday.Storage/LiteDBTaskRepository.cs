using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace NotToday.Storage {
  public class LiteDBTaskRepository: ITaskRepository {

    public string dbPath;
    private LiteCollection<Task> taskCollection;

    public LiteDBTaskRepository( string dbPath ) {
      this.dbPath = dbPath;
    }

    private LiteCollection<Task> GetTaskCollection() {
      if ( taskCollection == null ) {
        using ( var db = new LiteDatabase( dbPath ) ) {
          taskCollection = db.GetCollection<Task>();
        }
      }
      return taskCollection;
    }

    public Guid CreateOrUpdateTask( Task task ) {
      taskCollection = GetTaskCollection();
      if ( task.TaskId == null ) {
        task.TaskId = Guid.NewGuid();
        taskCollection.Insert( task );
      }
      else {
        taskCollection.Update( task );
      }
      return task.TaskId;
    }

    public void DelteteTask( Guid taskId ) {
      taskCollection = GetTaskCollection();
      var deletedTasks = taskCollection.Delete( t => t.TaskId == taskId );
      if ( deletedTasks == 0 ) {
        throw new ArgumentException( $"Task with id {taskId} doesn't exist." );
      }
    }

    public IEnumerable<Task> GetAllTasks() {
      var taskCollection = GetTaskCollection();
      return taskCollection.FindAll();
    }

    public Task GetTask( Guid taskId ) {
      var taskCollection = GetTaskCollection();
      return taskCollection.FindOne( t => t.TaskId == taskId );
    }
  }
}
