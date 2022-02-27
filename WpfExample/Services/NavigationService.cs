using Microsoft.Toolkit.Mvvm.ComponentModel;
using WpfExample.ViewModels;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Controls;
using System.Linq;

namespace WpfExample.Services
{
	public class NavigationService : ObservableObject
	{
		public void NavigateTo(object viewModel) {
			var vmName = viewModel
				.ToString()
				.Split(".", StringSplitOptions.TrimEntries)
				.Last();

			this.CurrentViewModel?.UnLoading();
			this.CurrentViewModel = (IViewModel)DummyIOC.Instance.ResolveByName(vmName);
			this.CurrentViewModel?.Loading();
		}

		public void NavigateTo(IViewModel viewModel)
		{
			this.CurrentViewModel?.UnLoading();
			this.CurrentViewModel = viewModel;
			this.CurrentViewModel.Loading();
		}

		private IViewModel _currentViewModel;
		public IViewModel CurrentViewModel
		{
			get => _currentViewModel;
			set => SetProperty(ref _currentViewModel, value);
		}

	}
}
