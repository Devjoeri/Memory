﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Memory
{
    class Sidebar
    {
        private Grid sidebar;
        protected string player1;
        protected string player2;
        private int player1Score, player2Score = 0;

        private string turn;

        private Label lplayer1 = new Label();
        private Label lplayer2 = new Label();
        public Sidebar(Grid SideBar)
        {
            this.sidebar = SideBar;
            this.player1 = "Joeri";
            this.player2 = "Jos";
            this.turn = player1;
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
                //AddScore();
                lplayer1.Dispatcher.Invoke(new Action(() => { lplayer1.Content = "Score " + this.player1 + ": " + this.player1Score; }));
            }
            if (player == player2)
            {
                player2Score++;
                lplayer2.Dispatcher.Invoke(new Action(() => { lplayer2.Content = "Score " + this.player2 + ": " + this.player2Score; }));
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
            player.Content = getTurn();
            player.FontSize = 15;
            player.HorizontalAlignment = HorizontalAlignment.Center;

            Grid.SetColumn(player, 0);
            Grid.SetRow(player, 9);

            sidebar.Children.Add(player);
        }
    }
}
