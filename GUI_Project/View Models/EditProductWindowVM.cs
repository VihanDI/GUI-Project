using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GUI_Project.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI_Project.View_Models
{
    public partial class EditProductWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string productName;

        [ObservableProperty]
        public string image;

        [ObservableProperty]
        public double price;

        int index;
        public EditProductWindowVM()
        {
            ProductName = null;
            image = null;
            price = 0;
        }

        public EditProductWindowVM(int id, string pname, string img, double p)
        {
            index = id;
            ProductName = pname;
            image = img;
            Price = p;
        }

        [RelayCommand]
        public void editStudent()
        {
            if (productName == "" || price <= 0 || image == "")
            {
                var window = new EmptyErrorMessageBox();
                window.ShowDialog();
            }
            else
            {
                using (var db = new DatabaseContext())
                {
                    var products = db.ListofProducts;
                    foreach (var p in products)
                    {
                        if (index == p.ProductID)
                        {
                            p.ProductName = productName;
                            p.Image = image;
                            p.Price = price;
                        }
                    }
                    db.SaveChanges();
                }

                var window = new SavedMessageBoxWindow();
                window.ShowDialog();
            }
        }
    }
}
