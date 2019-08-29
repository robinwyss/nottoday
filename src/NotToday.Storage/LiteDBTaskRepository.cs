using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;
using NotToday.Storage.Model;

namespace NotToday.Storage {
  public class LiteDBTaskRepository : ITaskRepository {

    public string dbPath;
    private LiteCollection<Task> _taskCollection;

    public LiteDBTaskRepository(string dbPath) {
      this.dbPath = dbPath;
    }

    public LiteDBTaskRepository() {
      this.dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinLiteDB.db");
    }

    private LiteCollection<Task> GetTaskCollection() {
      if (_taskCollection == null) {
        using (var db = new LiteDatabase(dbPath)) {
          _taskCollection = db.GetCollection<Task>();
        }
      }
      return _taskCollection;
    }

    public Guid CreateOrUpdateTask(Task task) {
      _taskCollection = GetTaskCollection();
      if (task.TaskId == Guid.Empty) {
        task.TaskId = Guid.NewGuid();
        _taskCollection.Insert(task);
      } else {
        _taskCollection.Update(task);
      }
      return task.TaskId;
    }

    public void DelteteTask(Guid taskId) {
      _taskCollection = GetTaskCollection();
      var deletedTasks = _taskCollection.Delete(t => t.TaskId == taskId);
      if (deletedTasks == 0) {
        throw new ArgumentException($"Task with id {taskId} doesn't exist.");
      }
    }

    public IEnumerable<Task> GetAllTasks() {
      var taskCollection = GetTaskCollection();
      return taskCollection.FindAll();
    }

    public IEnumerable<Task> GetTodaysTasks() {
      var taskCollection = GetTaskCollection();
      return taskCollection.Find(Query.Where("DueDate", dueDate => dueDate.AsDateTime.Date == DateTime.Today));
    }

    public Task GetTask(Guid taskId) {
      var taskCollection = GetTaskCollection();
      return taskCollection.FindOne(t => t.TaskId == taskId);
    }

    public IEnumerable<Task> GetFutureTasks() {
      var taskCollection = GetTaskCollection();
      return taskCollection.Find(Query.Where("DueDate", dueDate => dueDate.AsDateTime.Date > DateTime.Today));
    }


    public IEnumerable<Task> GetPastTasks() {
      var taskCollection = GetTaskCollection();
      return taskCollection.Find(Query.Where("DueDate", dueDate => dueDate.AsDateTime.Date < DateTime.Today));
    }
  }
}
  
