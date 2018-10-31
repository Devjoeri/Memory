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
    class JsonTools
    {
        /// <summary>
        /// Deze functie schrijft het megegeven object naar een json bestand met de megegeven naam
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="outputName"></param>
        public void writeToJson(object obj, string outputName)
        {
            string saveJson = JsonConvert.SerializeObject(obj);
            File.WriteAllText(outputName + ".json", saveJson);
        }
    }
}
