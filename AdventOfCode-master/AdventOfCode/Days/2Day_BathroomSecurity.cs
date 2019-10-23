using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days

{
    public class _2Day_BathroomSecurity : Day
    {
        private int _horizontal = 2;
        private int _vertical = 2;

        public _2Day_BathroomSecurity(int nymberOfDay) : base(nymberOfDay)
        {
        }

        public override string GetResult()
        {
            string wholenumber = "";

            foreach (var line in InputData)
            {
                ChangingFilds(line);
                wholenumber += NumberOfLine();
            }

            return "Code to Bathroom is: " + wholenumber;

        }

        private void ChangingFilds(string line) 
        {
            foreach (var key in line.ToCharArray())
            {
                switch (key)
                {
                    case 'U':
                        if (_vertical < 3)
                            _vertical++;
                        break;
                    case 'D':
                        if (_vertical > 1)
                            _vertical--;
                        break;
                    case 'R':
                        if (_horizontal < 3)
                            _horizontal++;
                        break;
                    case 'L':
                        if (_horizontal > 1)
                            _horizontal--;
                        break;
                }
            }
            
        }

        private int NumberOfLine()
        {
            var Tapls = ListOfTuple();
            int partialNumber = 0;

            foreach (var further in Tapls)
            {
                if ((further.Item2==_vertical) && (further.Item3==_horizontal))
                {
                    partialNumber = further.Item1;
                    return partialNumber;
                }
            }
            return partialNumber;
        }

        private List<Tuple<int, int, int>> ListOfTuple()
        {
            Tuple<int, int, int> key1 = new Tuple<int, int, int>(1, 3, 1);
            Tuple<int, int, int> key2 = new Tuple<int, int, int>(2, 3, 2);
            Tuple<int, int, int> key3 = new Tuple<int, int, int>(3, 3, 3);
            Tuple<int, int, int> key4 = new Tuple<int, int, int>(4, 2, 1);
            Tuple<int, int, int> key5 = new Tuple<int, int, int>(5, 2, 2);
            Tuple<int, int, int> key6 = new Tuple<int, int, int>(6, 2, 3);
            Tuple<int, int, int> key7 = new Tuple<int, int, int>(7, 1, 1);
            Tuple<int, int, int> key8 = new Tuple<int, int, int>(8, 1, 2);
            Tuple<int, int, int> key9 = new Tuple<int, int, int>(9, 1, 3);

            List<Tuple<int, int, int>> listOfTuples = new List<Tuple<int, int, int>>();

            listOfTuples.Add(key1);
            listOfTuples.Add(key2);
            listOfTuples.Add(key3);
            listOfTuples.Add(key5);
            listOfTuples.Add(key6);
            listOfTuples.Add(key7);
            listOfTuples.Add(key8);
            listOfTuples.Add(key9);

            /* for (int i = 0; i < 9; i++)
           {
               listOfTuples.Add("key"+i); wiem że tak nie mogę, ale kurde żeby to wszystko ręcznie pisać o,O ..do kitu, da się coś właśnie takiego, ale poprawnego wymyślić ?
           }*/

            return listOfTuples;
        }

    }
}