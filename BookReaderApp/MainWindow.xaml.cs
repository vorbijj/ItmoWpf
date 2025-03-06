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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace BookReaderApp
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

        private void mSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "eXtensible Application Markup Language file (*.xaml)|*.xaml";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = File.Open(saveFileDialog.FileName, FileMode.Create))
                {
                    XamlWriter.Save(docViewer.Document, fs);
                }
            }
        }

        private void mOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "eXtensible Application Markup Language file (*.xaml)|*.xaml";

            if (openFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = File.Open(openFileDialog.FileName, FileMode.Open))
                {
                    docViewer.Document = XamlReader.Load(fs) as FlowDocument;
                }
            }
        }

        private void mPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            bool? isPrinted = printDialog.ShowDialog();

            if (isPrinted != true)
            {
                return;
            }

            printDialog.PrintDocument(((IDocumentPaginatorSource)docViewer.Document).DocumentPaginator, "WPF Print Example");
        }

        private void mClear_Click(object sender, RoutedEventArgs e)
        {
            docViewer.ClearValue(FlowDocumentScrollViewer.DocumentProperty);
        }
    }
}
