using System;
using System.Collections.Generic;

namespace forms_hw3
{
    [Serializable]
    public class Worker
    {
        public string surname { get; set; }
        public int sallary { get; set; }
        public string poss { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int number { get; set; }

        public Worker() { }
        public Worker(string s, int sl, string pos, string c, string st, int n)
        {
            surname = s;
            sallary = sl;
            poss = pos;
            city = c;
            street = st;
            number = n;
        }

        public override string ToString()
        {
            return $"{surname},{sallary},{poss},{city},{street},{number}";
        }
    }
}
