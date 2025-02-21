using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProductsApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> products;
        public MainWindow()
        {
            InitializeComponent();
            products = new ObservableCollection<Product>
            {
                new Product()
                {
                    Name = "Мандарины",
                    Price = 120,
                    ImagePath = "Img/mandarine.jpg",
                    Category = ProductCategories.Food
                },
                new Product()
                {
                    Name = "Ананас",
                    Price = 370,
                    ImagePath = "Img/pineapple.jpg",
                    Category = ProductCategories.Food
                },
                new Product()
                {
                    Name = "Орехи",
                    Price = 250,
                    ImagePath = "Img/nuts.jpg",
                    Category = ProductCategories.Food
                },
                new Product()
                {
                    Name = "Утюг",
                    Price = 210,
                    ImagePath = "Img/flatiron.jpg",
                    Category = ProductCategories.Technic
                },
                new Product()
                {
                    Name = "Кофемашина",
                    Price = 12500,
                    ImagePath = "Img/coffee_machine.jpg",
                    Category = ProductCategories.Technic
                },
                new Product()
                {
                    Name = "Чайник",
                    Price = 510,
                    ImagePath = "Img/teapot.jpg",
                    Category = ProductCategories.Technic
                },
                new Product()
                {
                    Name = "Тостер",
                    Price = 470,
                    ImagePath = "Img/toaster.jpg",
                    Category = ProductCategories.Technic
                }
            };

            lstBoxProducts.ItemsSource = products;
        }
    }
}
