using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemFAT
{
    /// <summary>
    /// Содержит забаненные символы
    /// </summary>
    public static class BunnedSymbols
    {
        private static char[] BunnedAndOfficialSymbols = new char[] { '\\', '/', '.', '+', ';', ',', '=', '[', ']', '*', '?', '<', ':', '>', '|', '\"'};
        /// <summary>
        /// Вернет true, если есть забаненные символы, иначе false
        /// </summary>
        /// <param name="name">имя</param>
        /// <returns></returns>
        public static bool IsBunned(string name)
        {
            for (int i = 0; i < BunnedAndOfficialSymbols.Length; i++)
            {
                for (int j = 0; j < name.Length; j++)
                {
                    if (name[j] == BunnedAndOfficialSymbols[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
