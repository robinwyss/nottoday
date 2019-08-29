using System;

namespace NotToday.Storage.Model {
  public class Task {
    public Guid TaskId { get; internal set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }

    public Task() { }

    public Task(string title, string description, DateTime dueDate) {
      Title = title;
      Description = description;
      DueDate = dueDate;
    }
  }
}
