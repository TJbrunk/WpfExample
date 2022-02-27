using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Markup;
using WpfExample.Services;

namespace WpfExample.ViewModels
{
	public abstract class BaseViewModel : ObservableObject, IViewModel
	{
		public NavigationService NavService { get; private set; }

		public BaseViewModel(NavigationService navService)
		{
			this.NavService = navService;
		}

		public virtual void Loading() { }

		public virtual void UnLoading() { }

	}
}
