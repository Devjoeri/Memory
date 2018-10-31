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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Memory
{
 
    /// <summary>
    /// Hier halen we scores uit een JSON bestand, en plaatsen deze op de juiste plek.
    /// Om zo te laten zien wie er de meeste punten heeft behaald.
    /// </summary>
    public partial class Highscores : Page
    {
        public List<PlayerScore> Scores;
        public List<PlayerScore> ScoresToDisplay;
        public class PlayerScore
        {
            public int Id;
            public string playerName;
            public int Score;

            public PlayerScore(int Id,string playerName, int Score)
            {
                this.playerName = playerName;
                this.Score = Score;
                this.Id = Id;
            }

        }


        private INavigator _navigator;
        public Highscores(INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
           //writeHighscores();
           readHighscores();
        }
        
        public void writeHighscores()
        {
            Scores = new List<PlayerScore>();

            for (int i = 0; i < 6; i++)
            { 
                Scores.Add(new PlayerScore(i,"Jador", 120));
            }


            string saveJson = JsonConvert.SerializeObject(Scores);
            File.WriteAllText("highscores.json", saveJson);

        }

        public void readHighscores()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string JsonFile = File.ReadAllText("highscores.json");
            ScoresToDisplay = JsonConvert.DeserializeObject<List<PlayerScore>>(JsonFile);

            foreach (PlayerScore score in ScoresToDisplay)
            {

                switch(score.Id){
                    case 0:
                        naam0.Content = score.playerName;
                        score0.Content = score.Score;
                        break;
                    case 1:
                        naam1.Content = score.playerName;
                        score1.Content = score.Score;
                        break;
                    case 2:
                        naam2.Content = score.playerName;
                        score2.Content = score.Score;
                        break;
                    case 3:
                        naam3.Content = score.playerName;
                        score3.Content = score.Score;
                        break;
                    case 4:
                        naam4.Content = score.playerName;
                        score4.Content = score.Score;
                        break;
                    case 5:
                        naam5.Content = score.playerName;
                        score5.Content = score.Score;
                        break;
                }

            }

        }

        /// <summary>
        /// Button event om terug te gaan naar de homescreen/main menu screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void terug_highscore(object sender, RoutedEventArgs e)
        {
            _navigator.Navigate(new Mainmenu(_navigator));
        }
    }
}
