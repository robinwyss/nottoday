using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotTodayApp.Utils;
using NotTodayApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotTodayApp.Views {


  [XamlCompilation( XamlCompilationOptions.Compile )]
  public partial class TasksPage: ContentPage, IViewFor<TasksViewModel> {
    public TasksPage() {
      InitializeComponent();
      BindingContext = new TasksViewModel();
    }

    public TasksViewModel ViewModel { set => BindingContext = value; }

    private void AddItemClicked( object sender, EventArgs e ) {

    }

    private void ItemSelected( object sender, ItemTappedEventArgs e ) {
      var task = e.Item as NotTodayApp.Model.Task;
      var taskDetailVM = new TaskDetailViewModel( task );
      Navigation.PushAsync( new TaskDetailView( taskDetailVM ) );
    }
  
  }
}