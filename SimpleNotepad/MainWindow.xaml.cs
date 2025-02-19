using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
                string fontName = ((sender as ComboBox).SelectedItem as string);
                txtBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void cmbBoxSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtBox != null)
            {
                double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as string));
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

        private void mOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                txtBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void mSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, txtBox.Text);
            }
        }

        private void mQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cmbBoxThemes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nameAddTheme;
            string nameRemoveTheme;
            if (cmbBoxThemes.SelectedIndex == 0)
            {
                nameAddTheme = "LightTheme.xaml";
                nameRemoveTheme = "DarkTheme.xaml";
            }
            else
            {
                nameAddTheme = "DarkTheme.xaml";
                nameRemoveTheme = "LightTheme.xaml";
            }

            int count = 0;
            foreach(var item in Application.Current.Resources.MergedDictionaries)
            {
                if (item.Source.OriginalString == nameRemoveTheme)
                {
                    Application.Current.Resources.MergedDictionaries.RemoveAt(count);
                    break;
                }
                count++;
            }

            ResourceDictionary themeDct = new ResourceDictionary();
            themeDct.Source = new Uri(nameAddTheme, UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(themeDct);
        }
    }
}
