using System;
using System.Runtime.InteropServices;
using AdventOfCode.Days;

namespace AdventOfCode
{
    public class AdventCoordination
    {
        public void Start()
        {
            int numberOfDay = GetNumberOfDay();
            var day=SelectNumberToStart(numberOfDay);
            string result=day.GetResult();

            Console.WriteLine(result);
        }

        private int GetNumberOfDay()
        {
            int numberOfDay = 0;
            while (numberOfDay==0)
            {
                Console.WriteLine("Answer of which day do u prefer?");
                string unswerNrDay = Console.ReadLine();
                int.TryParse(unswerNrDay, out numberOfDay);
            }
            return numberOfDay;
        }

        private Day SelectNumberToStart(int numberOfDay)
        {
            Day day;
            switch (numberOfDay)
            {
                case 1:
                day = new _1Day_NoTimeForaTaxicab(1);
                break;

                case 2:
                    day=new _2Day_BathroomSecurity(2);
                    break;
                case 3:
                    day=new _3Day_SquaresWithThreeSides(3);
                    break;
                case 4:
                    day=new _4Day_SecurityThroughObscurity(4);
                    break;
                default:
                day = new Days.Day(0);
                break;
             }
            return day;
        }
    }
}