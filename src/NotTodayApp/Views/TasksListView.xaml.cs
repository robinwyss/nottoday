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

    public TaskListView() {
      InitializeComponent();
      viewModel = new TasksViewModel();
      BindingContext = viewModel;
    }


    private void ItemSelected(object sender, ItemTappedEventArgs e) {
      var taskId = (e.Item as Task).TaskId;
      Shell.Current.GoToAsync($"taskdetails?taskId={taskId}");
      //Navigation.PushAsync( new TaskDetailView( taskDetailVM ) );
    }


    protected override void OnAppearing() {
      base.OnAppearing();
      viewModel.LoadTasks();
    }
  }
}