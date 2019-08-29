using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotToday.Storage.Model;
using NotTodayApp.Utils;
using NotTodayApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotTodayApp.Views {


  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class TaskListView : ContentPage {
    private TasksViewModel viewModel;

    public string Time {
      get { return (string)GetValue(TimeProperty); }
      set { SetValue(TimeProperty, value); }
    }

    public static readonly BindableProperty TimeProperty =
    BindableProperty.Create(nameof(Time), typeof(string), typeof(TaskListView));

    public TaskListView() {
      InitializeComponent();
      viewModel = new TasksViewModel();
      BindingContext = viewModel;
    }


    private void ItemSelected(object sender, ItemTappedEventArgs e) {
      var taskId = (e.Item as Task).TaskId;
      //Shell.Current.GoToAsync($"//addtask");
      Shell.Current.GoToAsync($"taskdetails?taskId={taskId}");
      //Navigation.PushAsync( new TaskDetailView( taskDetailVM ) );
    }


    protected override void OnAppearing() {
      base.OnAppearing();
      if (Time == "today") {
        viewModel.LoadTasks(ViewModel.Time.Today);
      } else if (Time == "overdue") {
        viewModel.LoadTasks(ViewModel.Time.Overdue);
      } else {
        viewModel.LoadTasks(ViewModel.Time.Future);
      }
    }
  }
}