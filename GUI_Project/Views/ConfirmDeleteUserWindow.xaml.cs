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
    /// Interaction logic for ConfirmDeleteUserWindow.xaml
    /// </summary>
    public partial class ConfirmDeleteUserWindow : Window
    {
        public ConfirmDeleteUserWindow()
        {
            InitializeComponent();
        }

        int index;

        public ConfirmDeleteUserWindow(User user)
        {
            InitializeComponent();
            index = user.UserID;
        }

        private void Button_Yes(object sender, RoutedEventArgs e)
        {
            using (var db = new DatabaseContext())
            {
                var users = db.ListofUsers;
                foreach (var u in users)
                {
                    if (index == u.UserID)
                    {
                        db.Remove(u);
                        db.SaveChanges();
                    }
                }
            }
            Close();
        }

        private void Button_No(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
