using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public static class Base26System
    {
        private const int letterCount = 26;
        public static string Convert(int i)
        {
            string result = "";
            do
            {
                result += (char)(i % letterCount + 'A');
                i = i / letterCount;
            } while (i != 0);
            return result;
        }
    }
}
