using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace star1
{
    class ReadFile
    {
        private const String TEXT1 = @"https://dl.dropboxusercontent.com/u/28873424/tasks/simple_triangle.txt";
        private const String TEXT2 = @"https://dl.dropboxusercontent.com/u/28873424/tasks/triangle.txt";

        public string readFile()
        {
            WebClient wc = new WebClient();
            string theTextFile = wc.DownloadString(TEXT2);
            return theTextFile;
        }

    }
}
