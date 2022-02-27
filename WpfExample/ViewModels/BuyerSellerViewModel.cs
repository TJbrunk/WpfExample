using WpfExample.Services;

namespace WpfExample.ViewModels
{
	public class BuyerSellerViewModel : BaseViewModel
	{
		public BuyerSellerViewModel(NavigationService navService) : base(navService) { }
		public BuyerSellerViewModel() : base(null) { }

		private string _Title;
		public string Title
		{
			get => _Title;
			set => SetProperty(ref _Title, value);
		}

		private string _FirstName;
		public string FirstName
		{
			get => _FirstName;
			set => SetProperty(ref _FirstName, value);
		}

		private string _MiddleName;
		public string MiddleName
		{
			get => _MiddleName;
			set => SetProperty(ref _MiddleName, value);
		}

		private string _LastName;
		public string LastName
		{
			get => _LastName;
			set => SetProperty(ref _LastName, value);
		}
	}
}
