using WpfExample.Services;

namespace WpfExample.ViewModels
{
	public class PropertyViewModel : BaseViewModel
	{

		private string _address;
		public string Address
		{
			get => _address;
			set => SetProperty(ref _address, value);
		}

		private string _City;
		public string City
		{
			get => _City;
			set => SetProperty(ref _City, value);
		}

		private string _State;
		public string State
		{
			get => _State;
			set => SetProperty(ref _State, value);
		}

		private string _ZipCode;
		public string ZipCode
		{
			get => _ZipCode;
			set => SetProperty(ref _ZipCode, value);
		}

		public PropertyViewModel(NavigationService navService) : base(navService) { }

		public PropertyViewModel() : base(null) { }

		public override void Loading()
		{
			;
		}

		public override void UnLoading()
		{
			base.UnLoading();
		}
	}
}
