using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotTodayApp.Services {
  interface INavigationService {
     Task NagivateToAsync( string route );
  }
}
