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

namespace Memory
{
    /// <summary>
    /// Interaction logic for NaamInvoerenWindow.xaml
    /// </summary>
    public partial class NaamInvoerenWindow : INavigator
    {
        public NaamInvoerenWindow(INavigator mainNav)
        {
            InitializeComponent();
            Navigate(new NaamInvoeren(this,this, mainNav));
        }
        public void Navigate(Page p)
        {
            MainFrame.Navigate(p);
        }
    }
}
