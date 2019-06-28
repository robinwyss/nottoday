using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotTodayApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotTodayApp.Views {
  [XamlCompilation( XamlCompilationOptions.Compile )]
  public partial class TaskDetailView: ContentPage {
    public TaskDetailView( TaskDetailViewModel viewModel ) {
      InitializeComponent();
      BindingContext = viewModel;
    }
  }
}