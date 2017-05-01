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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WienerLinienApi.Samples.WPF_Proper.View;

namespace WienerLinienApi.Samples.WPF_Proper
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainWindow mW { set; get; }
        public MainView(MainWindow ThisMainWindow)
        {
            mW = ThisMainWindow;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (this.FindResource("LoginAnimation") as Storyboard);
            sb.Begin();

        }

        private void Login_Storyboard_Completed(object sender, EventArgs e)
        {
            mW.changeToLogin();
        }

        private void AddBusButton_Click(object sender, RoutedEventArgs e)
        {
            BusStopFavDialog dialog = new View.BusStopFavDialog();
            dialog.ShowDialog();
        }
    }
}
