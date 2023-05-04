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
using Microsoft.Win32;
using System.IO;

namespace Sport
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        SportDbContext sportDb = new SportDbContext();
        public AddProduct()
        {
            InitializeComponent();
            comboboxBoxManufacturer.ItemsSource = sportDb.ProductManufacturers.ToList();
            comboBoxCategory.ItemsSource = sportDb.ProductCategories.ToList(); 
            comboBoxUnitType.ItemsSource = sportDb.UnitTypes.ToList();  
            comboBoxMaxDiscountAmount.ItemsSource = sportDb.Products.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product
            {
                ProductArticleNumber = textBoxArticul.Text,
                ProductName = textBoxName.Text,             
                ProductCategoryId = ((ProductCategory)(comboBoxCategory.SelectedItem)).ProductCategoryId,
                ProductQuantityInStock = Int32.Parse(textBoxQuantityStock.Text),
                ProductManufacturerId = ((ProductManufacturer)(comboboxBoxManufacturer.SelectedItem)).ProductManufacturerId,
                UnitTypeId = ((UnitType)(comboBoxUnitType.SelectedItem)).UnitTypeId,
                ProductMaxDiscountAmount = Convert.ToByte(comboBoxMaxDiscountAmount.Text),
                ProductDiscountAmount = Convert.ToByte(textBoxProductDisountAmount.Text),
                ProductCost = Convert.ToDecimal(textBoxCost.Text),
                ProductPhoto = "photo",
                ProductDescription = textBoxDescription.Text,
                ProductSupplierId = ((ProductManufacturer)(comboboxBoxManufacturer.SelectedItem)).ProductManufacturerId,
            };
            sportDb.Add(product);
            sportDb.SaveChanges();
            MessageBox.Show("Успешно!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new AdminWindow().Show();
            Close();
        }

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // создаем диалоговое окно
            openFileDialog.ShowDialog(); // показываем
            byte[] image_bytes = File.ReadAllBytes(openFileDialog.FileName);
        }
    }
}
