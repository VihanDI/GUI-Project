using GUI_Project.View_Models;
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
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public EditProductWindow()
        {
            InitializeComponent();
            DataContext = new EditProductWindowVM();
        }

        public EditProductWindow(int id, string pname, string img, double p)
        {
            InitializeComponent();
            DataContext = new EditProductWindowVM(id, pname, img, p);
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            //var mainWindow = new MainWindow();
            //mainWindow.Show();
            //Close();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
