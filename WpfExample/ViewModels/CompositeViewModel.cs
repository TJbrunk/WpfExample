using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfExample.Services;

namespace WpfExample.ViewModels
{
	public class CompositeViewModel : BaseViewModel
	{
		public CompositeViewModel():base(null) { }

		private PropertyViewModel _propVM;

		public PropertyViewModel PropertyVM
		{
			get => _propVM;
			set => SetProperty(ref _propVM, value);
		}

		private BuyerSellerViewModel _buyerSellerVM;
		public BuyerSellerViewModel BuyerSellerVM
		{
			get => _buyerSellerVM;
			set => SetProperty(ref _buyerSellerVM, value);
		}

		public CompositeViewModel(NavigationService navService,
			PropertyViewModel propertyViewModel,
			BuyerSellerViewModel buyerSellerView) : base(navService)
		{
			this.PropertyVM = propertyViewModel;
			this.BuyerSellerVM = buyerSellerView;
		}

		public override void Loading()
		{
			this.PropertyVM.Loading();
			this.BuyerSellerVM.Loading();
		}
		public override void UnLoading()
		{
			this.PropertyVM.UnLoading();
			this.BuyerSellerVM.UnLoading();
		}
	}
}
