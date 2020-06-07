using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable.FAT
{
    internal class Cluster<T>
    {
        /// <summary>
        /// Указатель на левого сына
        /// </summary>
        public Cluster<T> LeftChild;
        /// <summary>
        /// Указатель на правого сына
        /// </summary>
        public Cluster<T> RightChild;
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
        public int ClusterNumber { get; set; }
        /// <summary>
        /// Создает еще один блок в файле (типо отображает на память). Размер блока должен быть = (размер кластера, установленный FS) / (размер Т (в байтах)).
        /// Например размер блока для каталожной записи (32 байта) и размера класетра в FS (4096 байт) будет равен 4096 / 32 == 128
        /// </summary>
        /// <param name="blockSize">размер блока дисковой памяти - зависит от размера T</param>
        /// <param name="blockNumber">номер этого блока в общем пространстве диска (раздела)</param>
        public Cluster(int blockSize, int blockNumber)
        {
            Block = new T[blockSize];
            ClusterNumber = blockNumber;
            nextFreeIndexInBlock = 0;
        }
        private int nextFreeIndexInBlock;
    }
}
