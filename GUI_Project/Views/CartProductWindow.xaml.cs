using GUI_Project.Models;
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

namespace GUI_Project.Views
{
    /// <summary>
    /// Interaction logic for CartProductWindow.xaml
    /// </summary>
    public partial class CartProductWindow : Window
    {
        Product product;

        public CartProductWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
        }

        public CartProductWindow(Product selectedProduct)
        {
            InitializeComponent();
            DataContext = new MainWindowVM(selectedProduct);
            product = selectedProduct;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            //sldr.Value = 1;
            Close();
        }

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(product.ProductName);
            Close();
        }
    }
}
