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
    }
}
