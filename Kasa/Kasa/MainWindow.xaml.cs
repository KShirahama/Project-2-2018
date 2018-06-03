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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kasa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Trasy(object sender, RoutedEventArgs e)
        {
            Trasy trasy = new Trasy();
            trasy.Show();
        }

        private void Button_Click_Lotniska(object sender, RoutedEventArgs e)
        {
            Lotniska lotniska = new Lotniska();
            lotniska.Show();
        }

        private void Button_Click_Samoloty(object sender, RoutedEventArgs e)
        {
            Samoloty samoloty = new Samoloty();
            samoloty.Show();
        }


    }
}
