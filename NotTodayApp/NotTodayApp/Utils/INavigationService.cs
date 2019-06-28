using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotTodayApp.Utils {
  interface INavigationService {

    Task Push( BaseViewModel viewModel );

    Task Pop();
  }
}
