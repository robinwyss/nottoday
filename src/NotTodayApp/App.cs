using System;
using System.Collections.Generic;
using NotToday.Storage;
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
      Routing.RegisterRoute("taskdetails", typeof(TaskDetailView));
      MainPage = new MainPage();

    }


    private void RegisterServicesAndProviders() {
      DependencyService.Register<LiteDBTaskRepository>();
      DependencyResolver.ResolveUsing(t => Dependencies.ContainsKey(t) ? Dependencies[t] : null);
      //var databasePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinLiteDB.db");
      //var liteDbTaskRepo = new LiteDBTaskRepository(databasePath);
      //Dependencies.Add(typeof(ITaskRepository), liteDbTaskRepo);
    }
  }
}
