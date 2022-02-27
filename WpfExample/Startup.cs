using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using WpfExample.Services;
using WpfExample.ViewModels;

namespace WpfExample
{
	public class Startup
	{
		public Dictionary<string, Type> VMNameMap = new Dictionary<string, Type>();
		public Dictionary<string, Type> ViewMap = new Dictionary<string, Type>();

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<NavigationService>();
			RegisterViews(services);
			RegisterViewModels(services);
		}

		private void RegisterViews(IServiceCollection services)
		{
			AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(x => x.GetTypes())
				.Where(x => x.Name.EndsWith("View")
					&& !x.IsInterface
					&& !x.IsAbstract
					&& x.BaseType == typeof(UserControl))
				.OrderBy(x => x.Name)
				.ToList()
				.ForEach(x => {
					this.ViewMap.Add(x.Name.Remove(x.Name.Length - "View".Length), x);
					services.AddTransient(x);
				});
		}

		private void RegisterViewModels(IServiceCollection services)
		{
			AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(x => x.GetTypes())
				.Where(x => typeof(IViewModel).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
				.OrderBy(x => x.Name)
				.ToList()
				.ForEach(x => {
					this.VMNameMap.Add(x.Name, x);
					services.AddTransient(x);
				});
		}
	}
}
