using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//include 
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Memory
{
    class Save
    {

        //info
        public int _size;
        public string _player1;
        public int _score1;
        public string _player2;
        public int _score2;
        public string _turn;
        //grid info
        //public int row, column, image;
            

        public Save(string player1, int score1, string player2, int score2, string turn,int size)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();

            //Set Save Data
            _player1 = player1;
            _player2 = player2;
            _score1 = score1;
            _score2 = score2;
            _turn = turn;
            _size = size;

            string saveJson = JsonConvert.SerializeObject(this);
            File.WriteAllText("Savetest.json", saveJson);
        }
    }
}
