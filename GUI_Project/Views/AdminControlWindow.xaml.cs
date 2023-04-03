using GUI_Project.Models;
using GUI_Project.View_Models;
using System;
using System.Collections;
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
    /// Interaction logic for AdminControlWindow.xaml
    /// </summary>
    public partial class AdminControlWindow : Window
    {
        public AdminControlWindow()
        {
            InitializeComponent();
            DataContext = new AdminControlWindowVM();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Navigation.SelectedIndex = 0;
        }

        private void Button_Add_User(object sender, RoutedEventArgs e)
        {
            Navigation.SelectedIndex = 1;
            usernameBox.Text = "";
            passwordBox.Text = "";
            AdminCheckBox.IsChecked = false;
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            User selectedUser = (List1.SelectedItem as User);

            if (selectedUser == null)
            {
                var window = new NotSelectedErrorWindow();
                window.ShowDialog();
            }
            else
            {
                var window = new ConfirmDeleteUserWindow(selectedUser);
                window.ShowDialog();
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Navigation.SelectedIndex = 0;
        }

        private void Button_Enter(object sender, RoutedEventArgs e)
        {
            //Navigation.SelectedIndex = 0;
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
