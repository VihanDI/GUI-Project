using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GUI_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GUI_Project.Views;

namespace GUI_Project.View_Models
{
    public partial class AddProductWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string productName;

        [ObservableProperty]
        public string image;

        [ObservableProperty]
        public double price;

        public AddProductWindowVM()
        {
            ProductName = null;
            image = null;
            price = 0;
        }

        [RelayCommand]
        public void InsertProduct()
        {
            Product p = new Product()
            {
                ProductName = productName,
                Image = image,
                Price = price
            };

            if (productName == "" || price <= 0 || image == "")
            {
                var window = new EmptyErrorMessageBox();
                window.ShowDialog();
            }
            else
            {
                using (var db = new DatabaseContext())
                {
                    db.ListofProducts.Add(p);
                    db.SaveChanges();
                }

                var window = new SavedMessageBoxWindow();
                window.ShowDialog();
            }
        }

        //test function to add products to the database
        public void addProduct(Product product)
        {
            if (product.ProductName == "" || product.Price <= 0 || product.Image == "")
            {
                var window = new EmptyErrorMessageBox();
                window.ShowDialog();
            }
            else
            {
                using (var db = new DatabaseContext())
                {
                    db.ListofProducts.Add(product);
                    db.SaveChanges();
                }

                var window = new SavedMessageBoxWindow();
                window.ShowDialog();
            }
        }
    }
}
