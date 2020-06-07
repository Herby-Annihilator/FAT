using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable.FAT
{
    /// <summary>
    /// Сама таблица FAT
    /// </summary>
    internal class FAT32
    {
        /// <summary>
        /// Размер таблицы
        /// </summary>
        private int tableSize;
        public int TableSize { get { return tableSize; } }
        /// <summary>
        /// Таблица свободных блоков
        /// </summary>
        private int[] blocks;
        /// <summary>
        /// Создает таблицу FAT указанного размера. Для получения в дальнейшем действительного размера таблицы
        /// используйте свойство TableSize, иначе проблем не оберетесь.
        /// </summary>
        /// <param name="tableSize">размер таблицы = количеству блоков на диске</param>
        public FAT32(int tableSize)
        {
            blocks = new int[tableSize + 2];   // 2 ячейки зарезервированы
            blocks[0] = GlobalConstants.EOC;
            blocks[1] = GlobalConstants.EOC;
            this.tableSize = tableSize + 2;
            for (int i = 2; i < this.tableSize; i++)
            {
                blocks[i] = 0;
            }
        }
        
        /// <summary>
        /// Возвращает следующий свободный кластер (блок). Если свободных нет, то вернет EOC
        /// </summary>
        /// <returns></returns>
        public int GetNextFreeBlock()
        {
            int toReturn = GlobalConstants.EOC;
            for (int i = 2; i < tableSize; i++)
            {
                if (blocks[i] == 0)
                {
                    toReturn = i;
                    blocks[i] = GlobalConstants.EOC;
                    break;
                }
            }
            return toReturn;
        }
        /// <summary>
        /// Возвращает следующий свободный кластер (блок), начиная с текущего (это должен быть номер стартового кластера файла или директории).
        /// Если свободных нет, то вернет EOC
        /// </summary>
        /// <param name="startBlock"></param>
        /// <returns></returns>
        public int GetNextFreeBlock(int startBlock)
        {
            int currentBlockIndex = startBlock;
            if (blocks[currentBlockIndex] != GlobalConstants.EOC)
            {
                while (blocks[currentBlockIndex] != GlobalConstants.EOC)
                {
                    currentBlockIndex = blocks[currentBlockIndex];
                }
                blocks[currentBlockIndex] = GetNextFreeBlock();
            }
            return blocks[currentBlockIndex];
        }
        /// <summary>
        /// Освобождает последовательность кластеров, на которых расположен файл/директория.
        /// Номер блока не превышает EOC и не может быть меньше 2.
        /// </summary>
        /// <param name="blockNumber">стартовый номер блока, на котором расположен файл/директория</param>
        /// <returns></returns>
        public bool FreeBlocks(int blockNumber)
        {
            if (blockNumber == GlobalConstants.EOC || blockNumber < 3)
            {
                return false;
            }
            else
            {
                int currentBlock = blockNumber;
                int nextBlock;
                while (currentBlock != GlobalConstants.EOC)
                {
                    nextBlock = blocks[currentBlock]; 
                    blocks[currentBlock] = 0;
                    currentBlock = nextBlock;
                }
                return true;
            }
        }
        /// <summary>
        /// Возвращает массив кластеров, на которых расположен файл/каталог
        /// </summary>
        /// <param name="startCluster">номер кластера, с которого начинается файл/каталог</param>
        /// <returns></returns>
        public int[] GetFileBlocks(int startCluster)
        {
            if (startCluster == GlobalConstants.EOC)
            {
                return null;
            }
            int currentCluster = startCluster;
            List<int> clusters = new List<int>();
            while (currentCluster != GlobalConstants.EOC)
            {
                clusters.Add(currentCluster);
                currentCluster = blocks[currentCluster];
            }
            return clusters.ToArray();
        }
    }
}
