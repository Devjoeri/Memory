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
    class Highscore
    {
        /// <summary>
        /// Deze functie schrijft de list met scores naar het json bestand
        /// </summary>
        /// <param name="Scores"></param>
        //public void writeHighscores(List<PlayerScore> Scores)
        //{
        //    List<PlayerScore> _Scores = Scores;
        //    Random rnd = new Random();

        //    for (int i = 0; i < 9; i++)
        //    {                
        //        Scores.Add(new PlayerScore(i,"Jador", rnd.Next(100,1000)));
        //    }


        //    string saveJson = JsonConvert.SerializeObject(Scores);
        //    File.WriteAllText("highscores.json", saveJson);

        //}

        //public void addScore(PlayerScore playerScore)
        //{
        //    List<PlayerScore> Scores = new List<PlayerScore>();
        //    Scores = readHighscores();

        //    if (Scores.Count >= 8)
        //    {
        //        Scores.RemoveAt(Scores.Count - 1);
        //        if (Scores.Count >= 8)
        //        {
        //            Scores.Add(playerScore);
        //        }
        //    }
        //    writeHighscores(Scores);
        //}

        /// <summary>
        /// Deze functie leest het json bestand in en geeft de list met scores terug
        /// </summary>
        /// <returns></returns>
        public List<PlayerScore> readHighscores()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string JsonFile = File.ReadAllText("highscores.json");
            return JsonConvert.DeserializeObject<List<PlayerScore>>(JsonFile);
        }
    }
}
