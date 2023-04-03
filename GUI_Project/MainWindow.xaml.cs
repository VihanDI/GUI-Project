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
            bool access = false;
            User currentUser = null;

            using (var db = new DatabaseContext())
            {
                var users = db.ListofUsers;
                foreach (var u in users)
                {
                    if (usernameBox.Text == u.Username && passBox.Password == u.Password)
                    {
                        access = true;
                        currentUser = u;
                        break;
                        
                    }
                    else
                    {
                        access = false;
                    }
                }
            }

            if (access)
            {
                validate.Visibility = Visibility.Hidden;
                if (currentUser.Type == "Admin")
                {
                    Navigation.SelectedIndex = 1;
                    sbox1.Text = "";
                    sbox2.Text = "";

                    var adminWindow = new AdminControlWindow();
                    adminWindow.ShowDialog();
                }
                else
                {
                    Navigation.SelectedIndex = 1;
                    sbox1.Text = "";
                    sbox2.Text = "";
                }
            }
            else
            {
                usernameBox.Text = "";
                passBox.Clear();
                validate.Visibility = Visibility.Visible;
            }

        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Navigation.SelectedIndex = 0;
            sbox1.Text = "";
            sbox2.Text = "";

            usernameBox.Text = "";
            passBox.Clear();
        }

        private void Button_Back_1(object sender, RoutedEventArgs e)
        {
            Navigation.SelectedIndex = 1;
            sbox1.Text = "";
            sbox2.Text = "";
        }

        private void Button_Products(object sender, RoutedEventArgs e)
        {
            Navigation.SelectedIndex = 2;
            sbox1.Text = "";
            sbox2.Text = "";
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
