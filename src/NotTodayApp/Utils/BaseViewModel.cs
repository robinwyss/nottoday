using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NotTodayApp.Utils {
  public abstract class BaseViewModel: INotifyPropertyChanged {

    public void OnPropertyChanged( string propertyName ) {
      PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
