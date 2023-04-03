using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GUI_Project.Models;
using GUI_Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI_Project.View_Models
{
    public partial class AdminControlWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public bool type;

        [ObservableProperty]
        public ObservableCollection<User> users;

        [RelayCommand]
        public void LoadUsers()
        {
            using (var db = new DatabaseContext())
            {
                var list = db.ListofUsers.ToList();
                Users = new ObservableCollection<User>(list);
            }
        }

        public AdminControlWindowVM()
        {
            username = null;
            password = null;
            Type = false;

            LoadUsers();
        }

        [RelayCommand]
        public void InsertUser()
        {
            string userType;

            if (type)
            {
                userType = "Admin";
            }
            else
            {
                userType = "Normal";
            }

            User u = new User()
            {
                Username = username,
                Password = password,
                Type = userType
            };

            if (username == "" || password == "")
            {
                var window = new EmptyErrorMessageBox();
                window.ShowDialog();
            }
            else
            {
                using (var db = new DatabaseContext())
                {
                    db.ListofUsers.Add(u);
                    db.SaveChanges();
                }

                var window = new SavedMessageBoxWindow();
                window.ShowDialog();
            }
        }
    }
}
