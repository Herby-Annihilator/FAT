using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands.DirectoryCommands
{
    public class CreateDirectory : Command
    {
        /// <summary>
        /// Атрибуты каталога
        /// </summary>
        private Attributes attributes;
        /// <summary>
        /// Имя каталога
        /// </summary>
        private string name;
        /// <summary>
        /// Размер каталога
        /// </summary>
        private int clusterSize;
        /// <summary>
        /// Ссылка на таблицу FAT
        /// </summary>
        public FAT32 FAT { get; set; }
        /// <summary>
        /// Ссылка на корневой каталог (необязательно прям корневой каталог, это должен быть текущий каталог)
        /// </summary>
        public Directory RootDirectory { get; set; }
        /// <summary>
        /// Создает каталог
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            int clusterNumber = FAT.GetNextFreeBlock();
            if (clusterNumber != GlobalConstants.EOC)
            {
                if (RootDirectory.IsThereFreeSpace(RootDirectory.LastUsedClusterNumber))
                {
                    return RootDirectory.CreateSubdirectory(name, attributes, clusterNumber);
                }
                else
                {
                    int clusterNumber2 = FAT.GetNextFreeBlock();
                    if (clusterNumber2 != GlobalConstants.EOC)
                    {
                        RootDirectory.Add(clusterSize, clusterNumber2);
                        return RootDirectory.CreateSubdirectory(name, attributes, clusterNumber);
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Создает команду "Создать директорию"
        /// </summary>
        /// <param name="clusterSize">размер кластера в байтах</param>
        /// <param name="directoryName">имя новой директории</param>
        /// <param name="hidden">будет ли директория скрыта</param>
        /// <param name="system">будет ли директория системной</param>
        /// <param name="fat">ссылка на таблицу FAT</param>
        /// <param name="rootDirectory">ссылка на текущий каталог</param>
        public CreateDirectory(int clusterSize, string directoryName, bool hidden, bool system, ref FAT32 fat, ref Directory rootDirectory)
        {
            attributes = new Attributes(true, hidden, system, false, true, false);
            FAT = fat;
            RootDirectory = rootDirectory;
            name = directoryName;
            this.clusterSize = clusterSize;
        }
    }
}
