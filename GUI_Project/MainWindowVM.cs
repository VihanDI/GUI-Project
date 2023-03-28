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

        [RelayCommand]
        public void LoadProducts()
        {
            using (var db = new DatabaseContext())
            {
                var list = db.ListofProducts.ToList();
                Products = new ObservableCollection<Product>(list);
            }
        }

        public MainWindowVM()
        {
            LoadProducts();
        }
    }
}
