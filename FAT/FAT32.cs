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
    public class FAT32
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
                    toReturn = blocks[i];
                }
            }
            return toReturn;
        }
        /// <summary>
        /// Если может, то освобождает блок с указанным номером. Номер блока не превышает EOC и не может быть меньше 2.
        /// В случае неудачи вернет false
        /// </summary>
        /// <param name="blockNumber">номер блока для освобождения</param>
        /// <returns></returns>
        public bool FreeBlock(int blockNumber)
        {
            if (blockNumber >= GlobalConstants.EOC)
            {
                return false;
            }
            if (blockNumber < 2)
            {
                return false;
            }
            blocks[blockNumber] = 0;
            return true;
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
