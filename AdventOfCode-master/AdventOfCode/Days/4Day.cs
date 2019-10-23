using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using AdventOfCode.Days;

namespace AdventOfCode.Days
{
    public class _4Day_SecurityThroughObscurity:Day
    { 
        public int Sum { get; set; }
        public string TestCheckSum;
        private string _key = "";
        private string _oneValue = "";
        public List<string> AfterRemoveDecoyData { get; set; }
        public int nrOfRoom { get; set; }
      
        public _4Day_SecurityThroughObscurity(int numberOfDay) : base(numberOfDay)
        {
        }

        public override string GetResult()
        {
            AfterRemoveDecoyData = InputData.ToList();

            foreach (var line in InputData)
            {
                IsItReal(line);
            }

            foreach (var line in AfterRemoveDecoyData)
            {
                nrOfRoom++;
                Decrypt(line);
            }

            return "Sum of real rooms ID's sector is : " + Sum;
        }

        private void IsItReal(string room)
        {
            //dereference of CHECKSUM from room's informations
            char[] bracket = {'[', ']'};
            var tochecksum= room.Split(bracket,StringSplitOptions.RemoveEmptyEntries).ToList();
            string checkSum = tochecksum[1];

            //dereference of NAME from room's informations
            var name = room.Split('-').ToList();
            name.RemoveAt(name.Count - 1);

            if (checkSum.Length == 5)
            {
                if (checkSum.Any(Char.IsLetter))
                {
                    if (checkSum.Any(Char.IsLower))
                    {
                        SetKeyAndOneValue(name);
                        SetTestChecksum(_key, _oneValue);
                        
                        if (checkSum == TestCheckSum)
                        {
                            int index=room.LastIndexOf('-');
                            string iiD=room.Remove(0, index+1);
                            iiD = iiD.Remove(3);

                            SendID(iiD);
                         }
                        else
                        {
                            var index = AfterRemoveDecoyData.FindIndex(c => c.Contains(room));
                            AfterRemoveDecoyData.RemoveAt(index);
                            
                        }
                        TestCheckSum = "";
                        _key = "";
                        _oneValue = "";
                    }
                }
             }
        }

        private void SetKeyAndOneValue(List<string> nameList)
        {
            var name = string.Join("", nameList.ToArray());
            Dictionary<char, int> partOfCheckSum = new Dictionary<char, int>();

            foreach (var letter in name)
            {
                if (!partOfCheckSum.ContainsKey(letter)) 
                {
                    partOfCheckSum.Add(letter, 1);
                }
                else
                {
                    partOfCheckSum[letter]++;
                }
            }

            var sortedPartOfCheckSum = partOfCheckSum.OrderBy(pair => pair.Key);
            var perfectsorted = sortedPartOfCheckSum.OrderByDescending(pair => pair.Value);

            foreach (var pair in perfectsorted)
            {
                _key += pair.Key;
            }
        }

        private void SetTestChecksum(string key, string oneValue)
        { 
            if (key.Length >= 5)
            {
                if (key.Length > 5)
                {
                    TestCheckSum = key.Remove(5);
                }
                else
                {
                    if (key.Length < 5)
                    {
                        TestCheckSum = key;
                    }                    
                }
            }
        }
        private void SendID(string id) 
        {
            int ID;
            int.TryParse(id, out ID);

            Sum += ID;
        }

        private void Decrypt(string realroom)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            //dereference of NAME from room's informations
            var name = realroom.Split('-').ToList();
            name.RemoveAt(name.Count - 1);
            
            int index = realroom.LastIndexOf('-');
            string iiD = realroom.Remove(0, index + 1);
            iiD = iiD.Remove(3);
            int id=int.Parse(iiD);

            int oIle=id%26;
            string word = "";
            string realname = "";

            for ( int i = 0; i < name.Count; i++)
            {
                foreach (var letter in name[i])
                {
                    int indexOfPlace=alphabet.IndexOf(letter);
                    int differential = 25 - indexOfPlace;

                    if (oIle > differential)
                    {
                        var usefulloIle = oIle;
                        usefulloIle -= differential;
                        word += alphabet[usefulloIle - 1];
                    }
                    else
                    {
                        indexOfPlace += oIle;
                        word += alphabet[indexOfPlace];
                    }
                    
                }
                realname =realname +" "+ word;
                word = "";
            }

            if (realname.Contains("north"))
            {
                Console.WriteLine("Id where the North Pole object are stored is : "+id+ realname);
            }
            else
            {
                Console.WriteLine(nrOfRoom + " "+ realname+id);
            }

        }

    }
}