﻿   using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

namespace WienerLinienApi.Samples.WPF.View
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


        private void AddBusButton_OnClick(object sender, RoutedEventArgs e)
        {
            BusStopFavDialog bsfd = new BusStopFavDialog();
            bsfd.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BusStopFavDialog bsfd = new BusStopFavDialog();
            bsfd.Show();
        }
    }
}
