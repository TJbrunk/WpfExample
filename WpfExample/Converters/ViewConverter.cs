﻿using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfExample.Converters
{

	public class ViewConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is UserControl)
			{
				return DummyIOC.Instance.Services.GetService(value.GetType());
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
