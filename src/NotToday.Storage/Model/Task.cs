using System;

namespace NotToday.Storage.Model {
  public class Task {
    public Guid TaskId { get; internal set; }
    public string Title { get; set; }
    public string Descripiton { get; set; }
    public DateTime DueDate { get; set; }

    public Task() { }

    public Task(string title, string descripiton, DateTime dueDate) {
      Title = title;
      Descripiton = descripiton;
      DueDate = dueDate;
    }
  }
}
