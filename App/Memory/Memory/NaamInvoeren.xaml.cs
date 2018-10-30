using System;
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
    /// hier pakken we de naam van de eerste speler.
    /// </summary>
    public partial class NaamInvoeren : Window
    {
        private string player1;
        private int gridsize = 4;
        public NaamInvoeren()
        {
            InitializeComponent();
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameInput.Text))
            {
                this.player1 = nameInput.Text;
                NaamInvoeren3 setupDialog = new NaamInvoeren3();
                setupDialog.ShowDialog();
            }
            
        }
    }
}
