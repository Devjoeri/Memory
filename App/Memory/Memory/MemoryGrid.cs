using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Card turnedCard;
        private object pic;
        private Image oldcard;
        private List<Card> images;
        Highscore _highscore;

        public MemoryGrid(Grid sidebar, Grid grid, int colums, int rows, string[] setup)
        {
            this.grid = grid;
            this.rows = rows;
            this.columns = colums;
            this.sidebar = new Sidebar(sidebar, setup, images);
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
            images = GetImagesList();
            
            for (int row = 0; row < rows; row++)
            {
                for(int column = 0; column < columns; column++)
                {
                    Image backgroundImage = new Image();
                    backgroundImage.Source = new BitmapImage(new Uri("Images/front.png", UriKind.Relative));
                    //backgroundImage.Source = images.First().getImage();
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
        private List<Card> GetImagesList()
        {
            List<Card> images = new List<Card>();
            for(int i = 0; i < rows*columns; i++)
            {
                int imageNr = i % 8 + 1; //De 8 is hardcoded, moet nog een variabele worden
                ImageSource source = new BitmapImage(new Uri("Images/"+imageNr+".png", UriKind.Relative));
                images.Add(new Card(source, imageNr));
            }
            Random random = new Random();
            int n = images.Count;
            for (int i = 0; i < images.Count; i++)
            {
                int rnd = random.Next(i + 1);

                Card value = images[rnd];
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
        private async void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            Card front = (Card)card.Tag;
            if (!front.matched())
            {
                card.Source = front.flipCard();
                cardsTurned++;
            }
            
            if (cardsTurned == 1)
            {
                oldcard = card;
                turnedCard = front;
            }

            if (cardsTurned == 2)
            {
                string player = sidebar.getTurn();
                if (front.getNumber() == turnedCard.getNumber())
                {
                    turnedCard.matched();
                    front.matched();
                    sidebar.AddPoint(player);
                }
                else
                {
                    await Task.Run(() =>
                    {
                        
                        Thread.Sleep(500);
                    });
                    oldcard.Source = turnedCard.flipCard();
                    card.Source = front.flipCard();
                }
                sidebar.setTurn(player);
                cardsTurned = 0;
            }
        }
    }
}
