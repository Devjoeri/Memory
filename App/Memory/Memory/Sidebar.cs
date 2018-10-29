using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Memory
{
    class Sidebar
    {
        private Grid sidebar;
        private string player1 = "Joeri";
        private string player2 = "Jos";
        private int player1Score, player2Score = 0;

        private string turn;
        public Sidebar(Grid SideBar)
        {
            this.sidebar = SideBar;
            initGrid();
            AddLabel();
            AddTurn();
            AddScore();
            AddButton("Opgeven", 1);
            AddButton("Help", 2);
            AddButton("Opslaan", 3);
        }
        public void initGrid()
        {
            for (int i = 0; i < 11; i++)
            {
                sidebar.RowDefinitions.Add(new RowDefinition());
            }

            sidebar.ColumnDefinitions.Add(new ColumnDefinition());
        }
        public void AddPoint(string player)
        {
            if (player == player1)
            {
                player1Score++;
            }
            if (player == player2)
            {
                player2Score++;
            }
        }
        public void setTurn()
        {

        }
        public string getTurn()
        {
            return turn;
        }
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
        private void AddButton(string buttonName, int pos)
        {
            Button button = new Button();
            button.Content = buttonName;
            button.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(button, 0);
            Grid.SetRow(button, pos);
            
            sidebar.Children.Add(button);
        }
        private void AddScore()
        {
            Label player1 = new Label();
            player1.Content = "Score playername: "+ player1Score;
            player1.FontSize = 10;
            player1.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(player1, 0);
            Grid.SetRow(player1, 6);

            sidebar.Children.Add(player1);
            Label player2 = new Label();
            player2.Content = "Score playername: "+player2Score;
            player2.FontSize = 10;
            player2.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(player2, 0);
            Grid.SetRow(player2, 7);

            sidebar.Children.Add(player2);
        }
        private void AddTurn()
        {
            Label turn = new Label();
            turn.Content = "Aan zet";
            turn.FontSize = 10;
            turn.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(turn, 0);
            Grid.SetRow(turn, 8);

            sidebar.Children.Add(turn);
            Label player = new Label();
            player.Content = "playername";
            player.FontSize = 15;
            player.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(player, 0);
            Grid.SetRow(player, 9);

            sidebar.Children.Add(player);
        }
    }
}
