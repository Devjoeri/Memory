using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
