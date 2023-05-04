using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        SportDbContext sportDb = new SportDbContext();
        public AdminWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = sportDb.Products.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddProduct().Show();
            Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new Auth().Show();
            Close();
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(((DataRowView)dataGrid.SelectedItem).Row[0].ToString());
            //dataGrid = sender as DataGrid;
            //DataGridRow row = (DataGridRow)dataGrid!.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            //DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            //string CellValue = ((TextBlock)RowColumn.Content).Text;
        }
    }
}
