using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Memory
{
    /// <summary>
    /// Hier maken we en setten we alle images voor het memory spel
    /// plaatsen we de kaarten gerandomized en omgedraait.
    /// De sidebar is apart gezet in een class
    /// </summary>
    class MemoryGrid
    {
        private Grid grid;
        private Sidebar sidebar;
        private int rows, columns;

        public object RowDefinitions { get; internal set; }

        private int cardsTurned = 0;
        private Image turnedCard;
        private object pic;

        public List<int> imagesList = new List<int>(); //Lijst met images zodat deze mee kan gegeven worden aan de save class

        public MemoryGrid(Grid sidebar, Grid grid, int colums, int rows)
        {
            this.grid = grid;
            this.rows = rows;
            this.columns = colums;
            this.sidebar = new Sidebar(sidebar);
            AddImages();
            initGrid(colums, rows);
            
        }
        /// <summary>
        /// Hier maken we de rows en columns aan voor de game grid
        /// </summary>
        /// <param name="colums"></param>
        /// <param name="rows"></param>
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

        /// <summary>
        /// Hier plaatsen we alle background images to op de plek voor de kaarten, en geven we ze een tag mee
        /// </summary>
        private void AddImages()
        {
            List<ImageSource> images = GetImagesList();
            
            for (int row = 0; row < rows; row++)
            {
                for(int column = 0; column < columns; column++)
                {
                    Image backgroundImage = new Image();
                    backgroundImage.Source = new BitmapImage(new Uri("Images/front.png", UriKind.Relative));
                    //backgroundImage.Source = images.First();
                    backgroundImage.Tag = images.First();
                    images.RemoveAt(0);
                    backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick);
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);
                }
            }
        }
        /// <summary>
        /// Hier randomize we de plaatjes voor de kaarten als je ze omdraait
        /// </summary>
        /// <returns></returns>
        private List<ImageSource> GetImagesList()
        {
            List<ImageSource> images = new List<ImageSource>();
            for(int i = 0; i < rows*columns; i++)
            {
                int imageNr = i % 8 + 1; //De 8 is hardcoded, moet nog een variabele worden
                ImageSource source = new BitmapImage(new Uri("Images/"+imageNr+".png", UriKind.Relative));
                images.Add(source);

                //Voeg Imagenr toe aan de lijst voor de save
                imagesList.Add(imageNr);
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

        /// <summary>
        /// Een event handler die af gaat als iemand op een kaart klikt, daar na slaan we de eerste op,
        /// en gaan we kijken of de tweede keuze overeen komt met de eerste.
        /// Zowel, worden er punten toegevoegt aan de speler die aan de beurd is.
        /// Zo niet, dan draaien we de kaarten weer om en is de volgende aan de beurt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
            cardsTurned++;
            if (cardsTurned == 1)
            {
                turnedCard = card;
            }
            if (cardsTurned == 2)
            {
                if (card.Uid == turnedCard.Uid)
                {
                    
                    string player = sidebar.getTurn();
                    sidebar.AddPoint(player);
                }
                //else
                //{
                    //turnedCard = new BitmapImage(new Uri("Images/front.png", UriKind.Relative));
                //}

            }         
        }

    }
}
