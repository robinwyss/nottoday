using System;
using System.Collections.Generic;
using System.Text;

namespace NotTodayApp.Utils {
  interface IViewFor<T> {

    T ViewModel { set; }

  }
}
