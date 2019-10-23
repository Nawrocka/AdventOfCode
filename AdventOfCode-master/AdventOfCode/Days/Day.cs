using System;
using System.Collections.Generic;
using AdventOfCode;

namespace AdventOfCode.Days
{
    public class Day
    {
        public int NumberOfDay { get; set; }
        protected List<string> InputData { get; set; }

        public Day(int numberOfDay)
        {
            NumberOfDay = numberOfDay;
            if (NumberOfDay != 0)
            {
                SetInputDataFromFile();
            }
        }

        private void SetInputDataFromFile()
        {
            string namefile = NumberOfDay+"Day.txt";
            InputData = StreamHelper.TakeReadFile(namefile);
        }

        public virtual string GetResult()
        {
            return "Unfortunately I don't have this day yet.";
        }
    }
}