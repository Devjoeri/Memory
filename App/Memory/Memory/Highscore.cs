using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Memory
{
    class Highscore : JsonTools
    {
        List<PlayerScore> _HighScores;

        public Highscore()
        {
        }

        /// <summary>
        /// Deze functie schrijft de megegeven highscores list naar een json bestand
        /// </summary>
        /// <param name="Highscores"></param>
        public void writeHighscores(List<PlayerScore> Highscores)
        {
            //Scores = new List<PlayerScore>();
            //Random rnd = new Random();

            //for (int i = 0; i < 9; i++)
            //{
            //    Scores.Add(new PlayerScore(i, "Jador", rnd.Next(100, 1000)));
            //}

            writeToJson(Highscores,"highscores");
        }

        /// <summary>
        /// Deze functie leest het json bestand in en geeft de list met scores terug
        /// </summary>
        /// <returns></returns>
        public List<PlayerScore> getScores()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<PlayerScore> scores;
            string JsonFile = File.ReadAllText("highscores.json");

            if (new FileInfo("highscores.json").Length == 0) {
                List<PlayerScore> tempScore = new List<PlayerScore>();
                tempScore.Add(new PlayerScore("Naam", 0));
                scores = tempScore;
            }
            else
            {
                scores = JsonConvert.DeserializeObject<List<PlayerScore>>(JsonFile);
            }
            
            return scores;
        }

        public void addScore(PlayerScore score)
        {
            if (_HighScores == null) {
                _HighScores = new List<PlayerScore>();
                _HighScores.Add(score);
            }
            else
            {
                _HighScores.Add(score);
                _HighScores = _HighScores.OrderByDescending(_scores => _scores.Score).ToList();
                writeHighscores(placeToId(_HighScores));
            }

        }

        public List<PlayerScore> placeToId(List<PlayerScore> highscores)
        {
            List<PlayerScore> _highscores = highscores;
            for (int i = 0; i < highscores.Count; i++)
            {
                highscores.ElementAt(i).Id = i;
            }
            return _highscores;
        }
    }
}
