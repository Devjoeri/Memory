using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Memory
{
    class MemoryGrid
    {
        private Grid grid;

        public MemoryGrid(Grid grid, int colums, int rows)
        {
            this.grid = grid;
            initGrid(colums, rows);
            AddLabel();
        }
        private void initGrid(int colums, int rows)
        {
            for(int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < colums; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
        private void AddLabel()
        {
            Label title = new Label();
            title.Content = "The game";
            title.FontSize = 40;
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(title, 1);
            grid.Children.Add(title);
        }
    }
}
