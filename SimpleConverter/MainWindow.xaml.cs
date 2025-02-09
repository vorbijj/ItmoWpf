using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleConverter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var txtBoxValue = (sender as TextBox).Text;

            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",")
               && (!txtBoxValue.Contains(",")
               && txtBoxValue.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void SetRateResult(string rate, string sum, TextBox resultBox)
        {
            try
            {
                resultBox.Text = (Convert.ToDouble(rate) * Convert.ToDouble(sum)).ToString("N2");
            }
            catch
            {
                resultBox.Text = "Введите корректные\nчисловые значения!";
            }
        }

        private void SetDistanceResult(string distance, double convert, TextBox resultBox)
        {
            try
            {
                resultBox.Text = (Convert.ToDouble(distance) * convert).ToString();
            }
            catch
            {
                resultBox.Text = "Введите корректные\nчисловые значения!";
            }
        }

        private void btnCalculateDollar_Click(object sender, RoutedEventArgs e)
        {
            SetRateResult(txtBoxRateDollar.Text, txtBoxSumDollar.Text, txtBoxResultDollar);
        }

        private void btnCalculateEuro_Click(object sender, RoutedEventArgs e)
        {
            SetRateResult(txtBoxRateEuro.Text, txtBoxSumEuro.Text, txtBoxResultEuro);
        }

        private void btnCalculateYuan_Click(object sender, RoutedEventArgs e)
        {
            SetRateResult(txtBoxRateYuan.Text, txtBoxSumYuan.Text, txtBoxResultYuan);
        }

        private void btnCalculateBtc_Click(object sender, RoutedEventArgs e)
        {
            SetRateResult(txtBoxRateBtc.Text, txtBoxSumBtc.Text, txtBoxResultBtc);
        }

        private void btnCalculateInch_Click(object sender, RoutedEventArgs e)
        {
            SetDistanceResult(txtBoxInch.Text, 0.0254, txtBoxResultInch);
        }

        private void btnCalculateFt_Click(object sender, RoutedEventArgs e)
        {
            SetDistanceResult(txtBoxFt.Text, 0.3048, txtBoxResultFt);
        }

        private void btnCalculateMile_Click(object sender, RoutedEventArgs e)
        {
            SetDistanceResult(txtBoxMile.Text, 1609.344, txtBoxResultMile);
        }

        private void btnCalculateVerst_Click(object sender, RoutedEventArgs e)
        {
            SetDistanceResult(txtBoxVerst.Text, 1066.8, txtBoxResultVerst);
        }
    }
}
