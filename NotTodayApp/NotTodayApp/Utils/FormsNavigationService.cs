using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotTodayApp.Utils {
  internal class FormsNavigationService: INavigationService {


    private INavigation FormsNavigation {
      get {
        return App.Current.MainPage.Navigation;
      }
    }

    public Dictionary<Type, Type> _viewModelViewDictionary { get; private set; } = new Dictionary<Type, Type>();

    public async Task Pop() {
      await FormsNavigation.PopAsync();
    }

    public async Task Push( BaseViewModel viewModel ) {
      var page = InstantiatePage( viewModel );
      await FormsNavigation.PushAsync( page );
    }

    private Page InstantiatePage( BaseViewModel viewModel ) {
      if ( _viewModelViewDictionary.TryGetValue( viewModel.GetType(), out Type page ) ) {
        var pageInstance = Activator.CreateInstance( page ) as Page;
        if ( pageInstance != null ) {
          return pageInstance;
        }
      }
      throw new ArgumentException( $"Could not find page for {viewModel}" );

    }

    public void RegisterViewModels( System.Reflection.Assembly asm ) {
      // Loop through everything in the assembley that implements IViewFor<T>
      foreach ( var type in asm.DefinedTypes.Where( dt => !dt.IsAbstract &&
     dt.ImplementedInterfaces.Any( ii => ii == typeof( IViewFor<> ) )
          ) ) {
        // get the ViewModel Type from the Attribute
        var viewForType = type.ImplementedInterfaces.FirstOrDefault( ii => ii.IsConstructedGenericType &&
          ii.GetGenericTypeDefinition() == typeof( IViewFor<> ));
        var viewModelType = viewForType.GenericTypeArguments[0];

        Register( viewModelType, type.AsType() );
      }
    }

    public void Register( Type viewModelType, Type viewType ) {
      _viewModelViewDictionary.Add( viewModelType, viewType );
    }
  }
}
