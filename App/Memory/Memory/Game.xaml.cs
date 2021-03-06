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

namespace Memory
{
    /// <summary>
    /// In deze class initializeren we de game grid,
    /// dit gebeurt in aparte classes
    /// </summary>
    public partial class Game : Page
    {
        MemoryGrid grid;
        private INavigator _navigator;
        public Game(INavigator navigator, string[] setup)
        {
            _navigator = navigator;
            InitializeComponent();
            grid = new MemoryGrid(SideBar, CardGrid, Int32.Parse(setup[3]), Int32.Parse(setup[3]), setup, _navigator);
            
        }
    }
}
