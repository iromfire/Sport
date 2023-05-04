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
using System.Windows.Shapes;

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
        
    {
        SportDbContext sportDb = new SportDbContext();
        public GuestWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = sportDb.Products.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = sportDb.Products.ToList().OrderBy(p => p.ProductCost);
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = sportDb.Products.ToList().OrderByDescending(p => p.ProductCost);
        }
    }
}
