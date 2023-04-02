﻿using System;
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
    /// Interaction logic for EmptyErrorMessageBox.xaml
    /// </summary>
    public partial class EmptyErrorMessageBox : Window
    {
        public EmptyErrorMessageBox()
        {
            InitializeComponent();
        }

        private void Button_Ok(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
