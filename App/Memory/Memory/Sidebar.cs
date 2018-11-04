using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Memory
{
    /// <summary>
    /// De aparte class voor de sidebar.
    /// Hier initializeren we de side bar, en geven we mee:
    /// De speler aanzet,
    /// De namen van speler 1 en 2,
    /// en de knoppen "opgeven", "help" en "opslaan"
    /// </summary>
    class Sidebar
    {
        private Grid sidebar;
        protected string player1;
        protected string player2;
        private int player1Score, player2Score = 0;

        private string turn;
        private INavigator _navigator;

        private Label lplayer1 = new Label();
        private Label lplayer2 = new Label();
        private Label tplayer = new Label();

        Highscore _highscore;
        List<Card> images;

        public Sidebar(Grid SideBar, string[] setup, List<Card> images, INavigator navigator)
        {
            _highscore = new Highscore();
            this.images = images;
            this.sidebar = SideBar;
            this.player1 = setup[1];
            this.player2 = setup[2];
            this.turn = player1;
            this._navigator = navigator;
            initGrid();
            AddLabel();
            AddTurn();
            AddScore();
            AddButton("Opgeven", 1, GiveUp);
            AddButton("Help", 2, HelpClick);
            AddButton("Opslaan", 3, SaveClick);
        }
        public void initGrid()
        {
            for (int i = 0; i < 11; i++)
            {
                sidebar.RowDefinitions.Add(new RowDefinition());
            }

            sidebar.ColumnDefinitions.Add(new ColumnDefinition());
        }

        /// <summary>
        /// Hier voegen we de punten toe aan de speler die aanzet is.
        /// </summary>
        /// <param name="player"></param>
        public void AddPoint(string player)
        {
            if (player == player1)
            {
                player1Score++;
                lplayer1.Dispatcher.Invoke(new Action(() => { lplayer1.Content = "Score " + this.player1 + ": " + this.player1Score; }));
            }
            if (player == player2)
            {
                player2Score++;
                lplayer2.Dispatcher.Invoke(new Action(() => { lplayer2.Content = "Score " + this.player2 + ": " + this.player2Score; }));
            }
        }
        /// <summary>
        /// Hier setten we de turn
        /// </summary>
        public void setTurn(string player)
        {
            if (player == player1)
            {
                turn = player2;
            }
            if(player == player2)
            {
                turn = player1;
            }
            tplayer.Dispatcher.Invoke(new Action(() => { tplayer.Content = turn; }));
        }
        /// <summary>
        /// Hier returne wij de turn, dus wie aan zet is
        /// </summary>
        /// <returns></returns>
        public string getTurn()
        {
            return turn;
        }

        /// <summary>
        /// Hier voegen we de label en de buttons toe aan de sidebar
        /// </summary>
        private void AddLabel()
        {
            Label title = new Label();
            title.Content = "The game";
            title.FontSize = 35;
            title.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(title, 0);
            sidebar.RowDefinitions[0].Height = new GridLength(100);
            sidebar.Children.Add(title);
        }

        private void AddButton(string buttonName, int pos, RoutedEventHandler method)
        {
            Button button = new Button();
            button.Content = buttonName;
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.Click += method;

            Grid.SetColumn(button, 0);
            Grid.SetRow(button, pos);
            
            sidebar.Children.Add(button);
        }
        /// <summary>
        /// Hier voegen we de tekst toe die tezien is in de sidebar, die aangeeft wie hoeveel punten heeft.
        /// </summary>
        private void AddScore()
        {
            
            lplayer1.Content = "Score "+ this.player1 + ": "+ this.player1Score;
            lplayer1.FontSize = 10;
            lplayer1.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(lplayer1, 0);
            Grid.SetRow(lplayer1, 6);
            

            sidebar.Children.Add(lplayer1);

            String content = "Score " + this.player2 + ": " + this.player2Score;
            lplayer2.Content = content;
            lplayer2.FontSize = 10;
            lplayer2.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(lplayer2, 0);
            Grid.SetRow(lplayer2, 7);

            sidebar.Children.Add(lplayer2);
            
            
        }
        
        /// <summary>
        /// Hier voegen we de label "aan zet" toe om aan tegeven wie zijn beurt het is.
        /// </summary>
        private void AddTurn()
        {
            Label turn = new Label();
            turn.Content = "Aan zet";
            turn.FontSize = 10;
            turn.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(turn, 0);
            Grid.SetRow(turn, 8);

            sidebar.Children.Add(turn);
            
            tplayer.Content = getTurn();
            tplayer.FontSize = 15;
            tplayer.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(tplayer, 0);
            Grid.SetRow(tplayer, 9);

            sidebar.Children.Add(tplayer);
        }
   
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Save");
            new Save(player1, player1Score, player2, player2Score,getTurn(),4, images);
            _highscore.addScore(new PlayerScore(player1, player1Score));
            _highscore.addScore(new PlayerScore(player2, player2Score));
        }
        private void HelpClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Help");
            
        }
        private void GiveUp(object sender, RoutedEventArgs e)
        {
            setTurn(getTurn());
            winner winnerWindow = new winner(_navigator, getTurn());
            winnerWindow.ShowDialog();

        }
    }
}
