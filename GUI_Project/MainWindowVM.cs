using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GUI_Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Project
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Product> products;

        [ObservableProperty]
        public ObservableCollection<Transaction> cart;

        public Product cartProduct;

        [ObservableProperty]
        public int quantity;

        [RelayCommand]
        public void LoadProducts()
        {
            using (var db = new DatabaseContext())
            {
                var list = db.ListofProducts.ToList();
                Products = new ObservableCollection<Product>(list);
            }
        }

        [RelayCommand]
        public void LoadCart()
        {
            using (var db = new DatabaseContext())
            {
                var list = db.ListofTransactions.ToList();
                Cart = new ObservableCollection<Transaction>(list);
            }
        }

        [RelayCommand]
        public void CartProducts()
        {
            Transaction purchase = new Transaction();
            purchase.Product = cartProduct.ProductName;
            purchase.Quantity = quantity;

            using (var db = new DatabaseContext())
            {
                db.ListofTransactions.Add(purchase);
                db.SaveChanges();
            }
            LoadCart();
        }

        public MainWindowVM()
        {
            LoadProducts();
            LoadCart();
        }

        public MainWindowVM(Product product)
        {
            LoadProducts();
            LoadCart();
            cartProduct = product;
        }
    }
}
