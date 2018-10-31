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
        Highscore _highscore;

        private INavigator _navigator;
        public Highscores(INavigator navigator)
        {
            InitializeComponent();
            _navigator = navigator;
            _highscore = new Highscore();
            //_highscore.addScore(new PlayerScore(0,"Jador",130));
            //_highscore.writeHighscores(Scores);
            writeHighscores();
            DisplayHighscores();
        }

        public void writeHighscores()
        {
            Scores = new List<PlayerScore>();
            Random rnd = new Random();

            for (int i = 0; i < 9; i++)
            {
                Scores.Add(new PlayerScore(i, "Jador", rnd.Next(100, 1000)));
            }


            string saveJson = JsonConvert.SerializeObject(Scores);
            File.WriteAllText("highscores.json", saveJson);

        }

        /// <summary>
        /// Deze functie displayed de list met highscores die hem meegeeft op de window
        /// </summary>
        /// <param name="scores"></param>
        public void DisplayHighscores()
        {

            JavaScriptSerializer ser = new JavaScriptSerializer();
            string JsonFile = File.ReadAllText("highscores.json");
            List<PlayerScore> scores = JsonConvert.DeserializeObject<List<PlayerScore>>(JsonFile);

            foreach (PlayerScore score in scores)
            {

                switch(score.Id){
                    case 0:
                        naam0.Content = score.playerName;
                        score0.Content = "Score: " + score.Score;
                        break;
                    case 1:
                        naam1.Content = score.playerName;
                        score1.Content = "Score: " + score.Score;
                        break;
                    case 2:
                        naam2.Content = score.playerName;
                        score2.Content = "Score: " + score.Score;
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
                    case 6:
                        naam6.Content = score.playerName;
                        score6.Content = score.Score;
                        break;
                    case 7:
                        naam7.Content = score.playerName;
                        score7.Content = score.Score;
                        break;
                    case 8:
                        naam8.Content = score.playerName;
                        score8.Content = score.Score;
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
