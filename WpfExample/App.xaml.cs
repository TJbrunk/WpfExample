using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Windows;
using WpfExample.ViewModels;

namespace WpfExample
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			var startup = new Startup();
			var host = Host.CreateDefaultBuilder()
				.ConfigureServices(startup.ConfigureServices)
				.Build();

			DummyIOC.Instance.Services = host.Services;
			DummyIOC.Instance.ViewModelMap = startup.VMNameMap;
			DummyIOC.Instance.ViewMap = startup.ViewMap;
			var window = new MainWindow();
			var vm = host.Services.GetRequiredService<MainWindowViewModel>();
			window.DataContext = vm;
			window.Show();
		}
	}

	public class DummyIOC
	{
		private static readonly DummyIOC instance = new DummyIOC();
		// These Dicts are a hack to resolve dependencies by name
		public Dictionary<string, Type> ViewMap;
		public Dictionary<string, Type> ViewModelMap;

		public IServiceProvider Services { get; set; }

		public object ResolveByName(string viewModelName) {
			var vm = ViewModelMap[viewModelName];
			return Services.GetRequiredService(vm);
		}
		public object ResolveViewForViewModel(IViewModel viewModel) {
			var vmName = viewModel.GetType().Name;
			var name = vmName.Remove(vmName.Length - "ViewModel".Length);
			var vm = ViewMap[name];
			return Services.GetRequiredService(vm);
		}

		static DummyIOC() { }
		private DummyIOC() { }

		public static DummyIOC Instance { get => instance; }

	}
}
