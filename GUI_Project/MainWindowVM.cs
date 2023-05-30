using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GUI_Project.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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
        public int quantity = 1;

        [ObservableProperty]
        public string searchWord1 = "";

        [ObservableProperty]
        public string searchWord2 = "";

        [ObservableProperty]
        public double subTotal = 0;

        public double UpdateSubTotal()
        {
            //SubTotal ++;
            double total = 0;
            
            using (var db = new DatabaseContext())
            {
                var products = db.ListofTransactions;
                foreach (var p in products)
                {
                    total = total + (p.UnitPrice * p.Quantity);
                }
            }

            return total;
        }

        //[ObservableProperty]
        //public string username;

        //[ObservableProperty]
        //public string password;

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
        public void SearchProducts1()
        {
            if (searchWord1 == "")
            {
                LoadProducts();
            }
            else
            {
                LoadProducts();

                int wordlength = searchWord1.Length;

                //var sortedProducts = Products.Where(p => p.ProductName.Substring(0, wordlength).ToLower() == searchWord1.ToLower()).ToList();
                var sortedProducts = Products.Where(p => p.ProductName.Length >= wordlength).ToList();
                var furtherSortedProducts = sortedProducts.Where(p => p.ProductName.Substring(0, wordlength).ToLower() == searchWord1.ToLower()).ToList();

                //Products = new ObservableCollection<Product>(sortedProducts);
                Products = new ObservableCollection<Product>(furtherSortedProducts);
            }

            /*
            using (var db = new DatabaseContext())
            {
                var products = db.ListofProducts;
                foreach (var p in products)
                {
                    if (searchWord == p.ProductName.Substring(0, wordlength))
                    {
                        
                    }
                }
            }
            */
        }

        [RelayCommand]
        public void SearchProducts2()
        {
            if (searchWord2 == "")
            {
                LoadProducts();
            }
            else
            {
                LoadProducts();

                int wordlength = searchWord2.Length;

                //var sortedProducts = Products.Where(p => p.ProductName.Substring(0, wordlength).ToLower() == searchWord2.ToLower()).ToList();
                var sortedProducts = Products.Where(p => p.ProductName.Length >= wordlength).ToList();
                var furtherSortedProducts = sortedProducts.Where(p => p.ProductName.Substring(0, wordlength).ToLower() == searchWord2.ToLower()).ToList();

                //Products = new ObservableCollection<Product>(sortedProducts);
                Products = new ObservableCollection<Product>(furtherSortedProducts);
            }

            /*
            using (var db = new DatabaseContext())
            {
                var products = db.ListofProducts;
                foreach (var p in products)
                {
                    if (searchWord == p.ProductName.Substring(0, wordlength))
                    {
                        
                    }
                }
            }
            */
        }

        [RelayCommand]
        public void LoadCart()
        {
            using (var db = new DatabaseContext())
            {
                var list = db.ListofTransactions.ToList();
                Cart = new ObservableCollection<Transaction>(list);
            }

            SubTotal = UpdateSubTotal();
        }

        [RelayCommand]
        public void CartProducts()
        {
            Transaction purchase = new Transaction();
            purchase.Product = cartProduct.ProductName;
            purchase.Quantity = quantity;
            purchase.UnitPrice = cartProduct.Price;

            using (var db = new DatabaseContext())
            {
                db.ListofTransactions.Add(purchase);
                db.SaveChanges();
            }
            LoadCart();
            //SubTotal = UpdateSubTotal();

            /*
            SubTotal = 0;
            using (var db = new DatabaseContext())
            {
                var products = db.ListofTransactions;
                foreach (var p in products)
                {
                    SubTotal = SubTotal + (p.UnitPrice * p.Quantity);
                }
            }
            */
        }

        [RelayCommand]
        public void ClearList()
        {
            using (var db = new DatabaseContext())
            {
                db.ListofTransactions.RemoveRange(Cart);
                db.SaveChanges();
            }
            LoadCart();

            SubTotal = 0;
        }

        [RelayCommand]
        public void CheckOut()
        {
            /*
            using (var db = new DatabaseContext())
            {
                var products = db.ListofTransactions;
                foreach (var p in products)
                {
                    SubTotal = SubTotal + (p.UnitPrice * p.Quantity);
                }
            }
            */

            using (var db = new DatabaseContext())
            {
                db.ListofTransactions.RemoveRange(Cart);
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
