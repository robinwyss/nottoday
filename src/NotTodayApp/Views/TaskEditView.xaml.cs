using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotTodayApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotTodayApp.Views {
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class TaskEditView : ContentPage {
    public TaskEditView() {
      InitializeComponent();
      BindingContext = new TaskEditViewModel();
    }
  }
}