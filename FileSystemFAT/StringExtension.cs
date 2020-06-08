using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemFAT
{
    public static class StringExtension
    {
        public static string GetSubstring(this string str, int startIndex, int lenght)
        {
            string toReturn = "";
            int substringLenght = str.Length - startIndex;
            if (substringLenght > lenght)
            {
                substringLenght = lenght;
            }
            for (int i = startIndex; i < startIndex + substringLenght; i++)
            {
                toReturn += str[i];
            }
            return toReturn;
        }
    }
}
