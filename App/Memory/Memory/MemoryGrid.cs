﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Memory
{
    class MemoryGrid
    {
        private Grid grid;
        private int rows, columns;

        public object RowDefinitions { get; internal set; }

        public MemoryGrid(Grid grid, int colums, int rows)
        {
            this.grid = grid;
            this.rows = rows;
            this.columns = colums;
            AddImages();
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
        private void AddImages()
        {
            List<ImageSource> images = GetImagesList();
            int counter = 0;
            for (int row = 0; row < rows; row++)
            {
                for(int column = 0; column < columns; column++)
                {
                    Image backgroundImage = new Image();
                    backgroundImage.Source = images[counter++];
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);
                }
            }
        }
        private List<ImageSource> GetImagesList()
        {
            List<ImageSource> images = new List<ImageSource>();
            for(int i = 0; i < rows*columns; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("Images/"+imageNr+".png", UriKind.Relative));
                images.Add(source);
            }
            Random random = new Random();
            int n = images.Count;
            for (int i = 0; i < images.Count; i++)
            {
                
                int rnd = random.Next(i + 1);

                ImageSource value = images[rnd];
                images[rnd] = images[i];
                images[i] = value;
            }
            return images;
        }
    }
}
