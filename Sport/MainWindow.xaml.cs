﻿using System;
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

namespace Sport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SportDbContext sportDb = new SportDbContext();
        public MainWindow(string name)
        {
            InitializeComponent();
            dataGrid.ItemsSource = sportDb.Products.ToList();
            Name = name;
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
