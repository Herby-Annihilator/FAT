using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable.FAT
{
    public class FileNode<T>
    {
        /// <summary>
        /// Указатель на левого сына
        /// </summary>
        public FileNode<T> LeftChild;
        /// <summary>
        /// Указатель на правого сына
        /// </summary>
        public FileNode<T> RightChild;
        /// <summary>
        /// Такая иллюзия блока дисковой памяти, размер желательно 4096.
        /// Для файла это просто будет массив char. 
        /// Для каталога это будет массив каталожных записей.
        /// В зависимости от назначения, работать с этим массивом нужно по разному
        /// </summary>
        public T[] Block { get; set; }
        /// <summary>
        /// Номер блока в таблице FAT (да и вообще в памяти)
        /// </summary>
        public int BlockNumber { get; set; }
        /// <summary>
        /// Создает еще один блок в файле (типо отображает на память)
        /// </summary>
        /// <param name="blockSize">размер блока дисковой памяти</param>
        /// <param name="blockNumber">номер этого блока в общем пространстве диска (раздела)</param>
        public FileNode(int blockSize, int blockNumber)
        {
            Block = new T[blockSize];
            BlockNumber = blockNumber;
        }
    }
}
