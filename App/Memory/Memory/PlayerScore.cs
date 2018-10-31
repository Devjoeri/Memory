using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class PlayerScore
    {
        public int Id;
        public string playerName;
        public int Score;

        public PlayerScore(string playerName, int Score)
        {
            this.playerName = playerName;
            this.Score = Score;
            this.Id = 0;
        }
    }
}
