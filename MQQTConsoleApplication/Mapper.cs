using System;
using System.Collections.Generic;
using System.IO;

namespace MQQTConsoleApplication
{
    class Mapper
    {
        readonly static string MAPPINGFILE = "config/MapConfig.txt";
        readonly static string VIEWPATH = "views/";
        static Dictionary<string, string> mappingDictionary;

        private Mapper()
        {

        }

        public static void buildDictionary()
        {
            mappingDictionary = new Dictionary<string, string>();
            string line;

            StreamReader file = new StreamReader(MAPPINGFILE);
            while((line = file.ReadLine()) != null)
            {
                string[] splitted = line.Split(':');
                Console.WriteLine(splitted[0]);
                Console.WriteLine(splitted[1]);
                mappingDictionary.Add(splitted[0].Trim(), splitted[1].Trim());
            }
        }

        public static StreamReader getMatchingFile(string key)
        {
            if (mappingDictionary.ContainsKey(key))
            {
                return new StreamReader(VIEWPATH + mappingDictionary[key]);
            }
            else
            {
                return null;
            }
        }
    }
}
