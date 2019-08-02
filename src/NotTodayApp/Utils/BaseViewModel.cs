using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace NotTodayApp.Utils {
  public abstract class BaseViewModel: INotifyPropertyChanged {

    public void OnPropertyChanged([CallerMemberName] string propertyName = null ) {
      PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
