using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdventOfCode.Days
{
    public class _3Day_SquaresWithThreeSides:Day
    {
        public int Count { get; set; }

        public _3Day_SquaresWithThreeSides(int numberOfDay) : base(numberOfDay)
        {
        }

        public override string GetResult()
        {
            char[] separator =new char[] { ' ' };
            foreach (var triangle in InputData)
            {
                var side = triangle.Split(separator,StringSplitOptions.RemoveEmptyEntries).ToList();
                SecondIfTriangle(side);
            }
            return "This is a number of possible triangles: "+Count; 
        }

        private void SecondIfTriangle(List<string> sideList)
        {
            List<int> sideIntList = sideList.Select(o => int.Parse(o)).ToList();

            if ((sideIntList[0]+sideIntList[1])>sideIntList[2])
            {
                if ((sideIntList[1] + sideIntList[2])> sideIntList[0])
                {
                    if ((sideIntList[2] + sideIntList[0])> sideIntList[1])
                    {
                        Count++;
                    }
                }
            }
        }       
    }
}