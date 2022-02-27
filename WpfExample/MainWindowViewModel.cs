using Microsoft.Toolkit.Mvvm.Input;
using WpfExample.Services;
using WpfExample.ViewModels;

namespace WpfExample
{
	public class MainWindowViewModel : BaseViewModel
	{
		public IRelayCommand<object> NavigateCmd { get; private set; }

		public MainWindowViewModel(NavigationService navService) : base(navService)
		{
			this.NavigateCmd = new RelayCommand<object>(vm => this.NavService.NavigateTo(vm));
		}
	}
}
