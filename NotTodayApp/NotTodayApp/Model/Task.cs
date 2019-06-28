using System;
using System.Collections.Generic;
using System.Text;

namespace NotTodayApp.Model {
  public class Task {
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }

    public Task( string name, string description, DateTime dueDate ) {
      Name = name;
      Description = description;
      DueDate = dueDate;
    }
  }
}
