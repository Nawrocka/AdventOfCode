using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    public static class StreamHelper
    {
        public static List<string> TakeReadFile(string path)
        {
            List<string> data=new List<string>();
            string line;
            FileStream fileStream=new FileStream(path,FileMode.Open);
            StreamReader streamReader=new StreamReader(fileStream);

            while ((line=streamReader.ReadLine())!=null)
            {
                data.Add(line);
            }
            return data;
        }
    }
}