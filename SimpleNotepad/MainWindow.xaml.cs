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

namespace SimpleNotepad
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

        private void cmbBoxFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtBox != null)
            {
                string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
                txtBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void cmbBoxSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtBox != null)
            {
                double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as TextBlock).Text);
                txtBox.FontSize = fontSize;
            }
        }

        private void btnBold_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox.FontWeight == FontWeights.Normal)
            {
                txtBox.FontWeight = FontWeights.Bold;
            }
            else
            {
                txtBox.FontWeight = FontWeights.Normal;
            }
        }

        private void btnItalic_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox.FontStyle == FontStyles.Normal)
            {
                txtBox.FontStyle = FontStyles.Italic;
            }
            else
            {
                txtBox.FontStyle = FontStyles.Normal;
            }
        }

        private void btnUnderline_Click(object sender, RoutedEventArgs e)
        {
            if (txtBox.TextDecorations.Count == 0) 
            {
                txtBox.TextDecorations.Add(TextDecorations.Underline);
            }
            else
            {
                txtBox.TextDecorations.RemoveAt(0);
            }
        }

        private void rbnBlack_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox != null && txtBox.Foreground != Brushes.Black)
            {
                txtBox.Foreground = Brushes.Black;
            }
        }

        private void rbnRed_Checked(object sender, RoutedEventArgs e)
        {
            if (txtBox != null && txtBox.Foreground != Brushes.Red)
            {
                txtBox.Foreground = Brushes.Red;
            }
        }
    }
}
