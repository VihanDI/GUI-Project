using GUI_Project.Models;
using GUI_Project.Views;
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

namespace GUI_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
        }

        private void Button_Sign_In(object sender, RoutedEventArgs e)
        {
            Navigation.SelectedIndex = 1;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Navigation.SelectedIndex = 0;
        }

        private void Button_Back_1(object sender, RoutedEventArgs e)
        {
            Navigation.SelectedIndex = 1;
        }

        private void Button_Products(object sender, RoutedEventArgs e)
        {
            Navigation.SelectedIndex = 2;
        }

        private void Add_To_Cart(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = (List1.SelectedItem as Product);

            if(selectedProduct == null)
            {
                NotSelectedErrorWindow window = new NotSelectedErrorWindow();
                window.ShowDialog();
            }
            else
            {
                CartProductWindow window = new CartProductWindow(selectedProduct);
                window.ShowDialog();
            }
        }

        private void Button_Add_Products(object sender, RoutedEventArgs e)
        {
            AddProductWindow window = new AddProductWindow();
            window.ShowDialog();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = (List3.SelectedItem as Product);

            if (selectedProduct == null)
            {
                var window = new NotSelectedErrorWindow();
                window.ShowDialog();
            }
            else
            {
                var window = new EditProductWindow(selectedProduct.ProductID, selectedProduct.ProductName, selectedProduct.Image, selectedProduct.Price);
                window.ShowDialog();
            }
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = (List3.SelectedItem as Product);

            if (selectedProduct == null)
            {
                var window = new NotSelectedErrorWindow();
                window.ShowDialog();
            }
            else
            {
                var window = new ConfirmDeleteMessageBox(selectedProduct);
                window.ShowDialog();
            }
        }
    }
}
