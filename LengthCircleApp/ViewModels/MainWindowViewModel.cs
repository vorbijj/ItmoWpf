using LengthCircleApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LengthCircleApp.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private double? radius;
        private double? lengthCircle;

        public double? Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        public double? LengthCircle
        {
            get => lengthCircle;
            set
            {
                lengthCircle = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalculateCommand { get; }
        public ICommand PreviewTextInputCommand { get; }
        public ICommand PreviewKeyDownCommand { get; }

        private void OnCalculateCommandExecute(object parameter)
        {
            LengthCircle = GeometricCalculation.GetCircumference(Radius);
        }

        private void OnPreviewTextInputCommandExecute(object parameter)
        {
            var e = (TextCompositionEventArgs)parameter;
            var currenttext = (e.Source as TextBox).Text;

            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!currenttext.Contains(".")
               && currenttext.Length != 0)))
            {
                e.Handled = true;
            }
            else
            {
                if (LengthCircle.HasValue)
                {
                    LengthCircle = null;
                }
            }
        }

        private void OnPreviewKeyDownCommandExecute(object parameter)
        {
            var e = (KeyEventArgs)parameter;
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                if (LengthCircle.HasValue)
                {
                    LengthCircle = null;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            CalculateCommand = new RelayCommand(OnCalculateCommandExecute);
            PreviewTextInputCommand = new RelayCommand(OnPreviewTextInputCommandExecute);
            PreviewKeyDownCommand = new RelayCommand(OnPreviewKeyDownCommandExecute);
        }
    }
}
