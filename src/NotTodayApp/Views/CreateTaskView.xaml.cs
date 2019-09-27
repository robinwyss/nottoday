using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotTodayApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace NotTodayApp.Views {
  [XamlCompilation( XamlCompilationOptions.Compile )]
  public partial class CreateTaskView: ContentPage {
    private readonly CreateTaskViewModel viewModel;

    public CreateTaskView() {
      InitializeComponent();
      viewModel = new CreateTaskViewModel();
      BindingContext = viewModel;
    }

    protected override void OnAppearing() {
      base.OnAppearing();
      Xamarin.Forms.Application.Current.On<Android>().UseWindowSoftInputModeAdjust( WindowSoftInputModeAdjust.Resize );
      viewModel.Init();
    }
  }
}