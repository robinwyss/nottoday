using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NotTodayApp.Services {
  class ShellNavigationService: INavigationService {
    public async System.Threading.Tasks.Task NagivateToAsync( string route ) {
      await Shell.Current.GoToAsync( route );
    }

    public async System.Threading.Tasks.Task NavigateBackAsync() {
      await Shell.Current.Navigation.PopAsync();
    }
  }
}
