﻿using System;
using System.Collections;
using LiveChartsCore.SkiaSharpView.Painting;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI;

namespace UWPSample.Pies.Processing
{
    public sealed partial class View : UserControl
    {
        public View()
        {
            InitializeComponent();
        }
    }

    public class PaintTaskToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is not IEnumerable enumerable) return null;

            var enumerator = enumerable.GetEnumerator();
            return enumerator.MoveNext() && enumerator.Current is SolidColorPaintTask solidPaintTask
                ? new SolidColorBrush(Color.FromArgb(
                    solidPaintTask.Color.Alpha,
                    solidPaintTask.Color.Red,
                    solidPaintTask.Color.Green,
                    solidPaintTask.Color.Blue))
                : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
