using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExampleDependencyProperty
{
    enum Precipitation
    {
        Sunny,
        Cloudy,
        Rain,
        Snow
    }

    internal class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private Precipitation precipitation;

        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }

        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public WeatherControl(string windDirection, int windSpeed, Precipitation precipitation)
        {
            WindDirection = windDirection;
            WindSpeed = windSpeed;
            this.precipitation = precipitation;
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(Object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t <= 50)
            {
                return t;
            }
            else
            {
                return 0;
            }
        }
    }
}
