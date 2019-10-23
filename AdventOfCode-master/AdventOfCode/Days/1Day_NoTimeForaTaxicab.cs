using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    class _1Day_NoTimeForaTaxicab : Day
    {
        private int _horizontal;
        private int _vertical;
        private int _direction;
        private int _position;
        public int x { get; set; }
        public int y { get; set; }

        public _1Day_NoTimeForaTaxicab(int numberOfDay) : base(numberOfDay)
        {
            _position = 0;
        }

        public override string GetResult()
        {
            string inputData = string.Join(" ", InputData.ToArray());
            var separated = inputData.Split(',');

            foreach (var inputDataElement in separated)
            {
                int numberOfElement = GetNumberOfElementToGo(inputDataElement);
                GoToNewPossition(inputDataElement,numberOfElement);
            }
            int sumOfDirections = Math.Abs(y) + Math.Abs(x);
            return "Wynik to: " + sumOfDirections;
        }

        private void GoToNewPossition(string inputDataElement, int numberOfElement)
        {
            switch (_position)
            {
                case 0:                    
                    if(inputDataElement.Contains('R'))
                    {
                        x += numberOfElement;
                        _position = 2;
                    }
                    if (inputDataElement.Contains('L'))
                    {
                        x -= numberOfElement;
                        _position = 3;
                    }
                    break;
                case 1:
                    {
                        if (inputDataElement.Contains('R'))
                        {
                            x -= numberOfElement;
                            _position = 3;
                        }
                        if (inputDataElement.Contains('L'))
                        {
                            x += numberOfElement;
                            _position = 2;
                        }
                        break;
                    }
                case 2:
                    {
                        if (inputDataElement.Contains('R'))
                        {
                            y -= numberOfElement;
                            _position = 1;
                        }
                        if (inputDataElement.Contains('L'))
                        {
                            y += numberOfElement;
                            _position = 0;
                        }
                        break;
                    }
                case 3:
                    if (inputDataElement.Contains('R'))
                    {
                        y += numberOfElement;
                        _position = 0;
                    }
                    if (inputDataElement.Contains('L'))
                    {
                        y -= numberOfElement;
                        _position = 1;
                    }
                    break;
            }
        }
      
        private int GetNumberOfElementToGo(string inputDataElement)
        {
            string stringNumber = "";
            int number;

            for (int i = 0; i < inputDataElement.Length; i++)
            {
                if (char.IsDigit(inputDataElement[i]))
                {
                    stringNumber += inputDataElement[i];
                }
            }

            if (int.TryParse(stringNumber, out number))
                return number;
            else return -1;            
        }

    }
}
