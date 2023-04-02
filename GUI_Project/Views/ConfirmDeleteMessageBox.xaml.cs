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
using GUI_Project.Models;

namespace GUI_Project.Views
{
    /// <summary>
    /// Interaction logic for ConfirmDeleteMessageBox.xaml
    /// </summary>
    public partial class ConfirmDeleteMessageBox : Window
    {
        public ConfirmDeleteMessageBox()
        {
            InitializeComponent();
        }

        int index;

        public ConfirmDeleteMessageBox(Product product)
        {
            InitializeComponent();
            index = product.ProductID;
        }

        private void Button_Yes(object sender, RoutedEventArgs e)
        {
            using (var db = new DatabaseContext())
            {
                var products = db.ListofProducts;
                foreach (var p in products)
                {
                    if (index == p.ProductID)
                    {
                        db.Remove(p);
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
