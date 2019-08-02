using System;

namespace NotToday.Storage {
  public class Task {
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public string Descripiton { get; set; }
    public DateTime DueDate { get; set; }
  }
}
