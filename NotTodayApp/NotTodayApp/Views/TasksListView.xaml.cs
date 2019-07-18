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
  public partial class TaskListView: ContentPage {
    public TaskListView() {
      InitializeComponent();
      BindingContext = new TasksViewModel();
    }

    private void AddItemClicked( object sender, EventArgs e ) {

    }

    private void ItemSelected( object sender, ItemTappedEventArgs e ) {
      var task = e.Item as NotTodayApp.Model.Task;
      var taskDetailVM = new TaskDetailViewModel( task );
      Shell.Current.GoToAsync( "taskdetails" );
      //Navigation.PushAsync( new TaskDetailView( taskDetailVM ) );
    }
  
  }
}