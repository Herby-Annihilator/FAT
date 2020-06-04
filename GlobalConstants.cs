using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable
{
    /// <summary>
    /// Необходимые константы
    /// </summary>
    public static class GlobalConstants
    {
        /// <summary>
        /// Метка конца файла
        /// </summary>
        public const int EOC = 268435455;  // метка конца файла
        /// <summary>
        /// Максимальный номер блока в таблице FAT32 2^16
        /// </summary>
        public const int FIRST_BLOCK_MAX_NUMBER = 65535;
        /// <summary>
        /// Максимальный размер файла (2^28 32 бита)
        /// </summary>
        public const int MAX_FILE_SIZE = 268435455;
    }
}
