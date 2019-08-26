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
    private readonly TaskEditViewModel viewModel;

    public TaskEditView() {
      InitializeComponent();
      viewModel = new TaskEditViewModel();
      BindingContext = viewModel;
    }

    protected override void OnAppearing() {
      base.OnAppearing();
      viewModel.Init();
    }
  }
}