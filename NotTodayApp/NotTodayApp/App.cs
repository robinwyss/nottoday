using System;
using NotTodayApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation( XamlCompilationOptions.Compile )]
namespace NotTodayApp {
  public class App: Application {
    public App() {
      //InitializeComponent();
      Routing.RegisterRoute( "taskdetails", typeof( TaskDetailView ) );
      MainPage = new MainPage();
    }

    private void Bootstrap() {
      var databasePath = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ), "XamarinLiteDB.db" );

    }

    protected override void OnStart() {
      // Handle when your app starts
    }

    protected override void OnSleep() {
      // Handle when your app sleeps
    }

    protected override void OnResume() {
      // Handle when your app resumes
    }
  }
}
