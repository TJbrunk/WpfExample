using WpfExample.Services;

namespace WpfExample.ViewModels
{

	public interface IViewModel
	{
		NavigationService NavService { get; }
		void Loading();
		void UnLoading();
	}
}
