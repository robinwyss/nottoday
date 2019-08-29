using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotTodayApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotTodayApp.Views {

  [QueryProperty("TaskId", "taskId")]
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class TaskDetailView : ContentPage {
    private readonly TaskDetailViewModel viewModel;

    public string TaskId {
      set {
        viewModel.LoadTask(value);
      }
    }

    public TaskDetailView() {
      InitializeComponent();
      var current = Shell.Current;
      viewModel = new TaskDetailViewModel();
      BindingContext = viewModel;
    }
  }
}