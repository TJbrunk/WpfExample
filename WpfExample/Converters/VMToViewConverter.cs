using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using WpfExample.ViewModels;

namespace WpfExample.Converters
{

	public class VMToViewConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is IViewModel)
			{
				var view = (UserControl)DummyIOC.Instance.ResolveViewForViewModel((IViewModel)value);
				view.DataContext = value;
				return view;
			}
			else
			{
				return null;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
