using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//include 
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Windows;
using static System.Environment;

namespace Memory
{
    class Save : JsonTools
    {
        
        //info
        public int size;
        public string player1;
        public int score1;
        public string player2;
        public int score2;
        public string turn;
        public List<card> kaarten;
        List<Card> imageList;
        MemoryGrid memo;

        //grid info
        //public int row, column, image;
        public class card
        {
            public int row, column, image;
            public bool turned;

            public card(int row, int column, int image, bool turned)
            {
                this.row = row;
                this.column = column;
                this.image = image;
                this.turned = turned;
            }

        }; 

        /// <summary>
        /// Slaat alle game data op met de meegegeven informatie
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="score1"></param>
        /// <param name="player2"></param>
        /// <param name="score2"></param>
        /// <param name="turn"></param>
        /// <param name="size"></param>
        public Save(string player1, int score1, string player2, int score2, string turn,int size, List<Card> images)
        {
            //var directory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            JavaScriptSerializer ser = new JavaScriptSerializer();

            //Set Save Data
            this.player1 = player1;
            this.player2 = player2;
            this.score1 = score1;
            this.score2 = score2;
            this.turn = turn;
            this.size = size;
            this.imageList = images;
            kaarten = new List<card>();

            //Plaatje op welke plek
            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    //int image = getCardImage(row,column);
                    //int image = 0;
                    //kaarten.Add(new card(row,column,image,true));
                    Console.WriteLine(images);
                }
            }

            writeToJson(this, "save");
        }
    }
}
