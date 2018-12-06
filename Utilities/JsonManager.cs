using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPITest.Utilities
{
    class JsonManager
    {
        public static string JsonString(string path)
        {
            string json = "";
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    json = json + sr.ReadLine();
                }
            }
            return json;
        }
    }
}
