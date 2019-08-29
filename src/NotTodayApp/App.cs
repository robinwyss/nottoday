using System;
using System.Collections.Generic;
using NotToday.Storage;
using NotTodayApp.Services;
using NotTodayApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NotTodayApp {
  public class App : Application {

    public Dictionary<Type, object> Dependencies = new Dictionary<Type, object>();
    public App() {
      RegisterServicesAndProviders();
      //Routing.RegisterRoute( "today", typeof( TaskListView ) );
      //Routing.RegisterRoute( "nottoday", typeof( TaskListView ) );
      //Routing.RegisterRoute( "addtask", typeof( TaskListView ) );
      Routing.RegisterRoute("taskdetails", typeof(TaskDetailView));
      MainPage = new MainPage();

    }


    private void RegisterServicesAndProviders() {
      DependencyService.Register<LiteDBTaskRepository>();
      DependencyService.Register<ShellNavigationService>();
      DependencyResolver.ResolveUsing(t => Dependencies.ContainsKey(t) ? Dependencies[t] : null);
      //var databasePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinLiteDB.db");
      //var liteDbTaskRepo = new LiteDBTaskRepository(databasePath);
      //Dependencies.Add(typeof(ITaskRepository), liteDbTaskRepo);
    }
  }
}
