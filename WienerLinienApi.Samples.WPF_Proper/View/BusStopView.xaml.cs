﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WienerLinienApi.Samples.WPF_Proper.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class BusStopView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _stopName;
        public string StopName {
            get { return _stopName; }
            private set
            {
                _stopName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StopName"));
            }
        }
        public BusStopView(string stop, string line, string newxtBus)
        {
            InitializeComponent();

            BusStopNameLabel.Text = stop;
            LineName.Text = line;
            NextBus.Text = newxtBus;
        }
    }
}
