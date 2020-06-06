using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;
using FileAllocationTable.Commands.FileCommands;

namespace FileAllocationTable.Commands.DirectoryCommands
{
    public class CreateDirectory : Command
    {
        private FileSystem fileSystem;
        /// <summary>
        /// Номер первого кластера директории-родителя
        /// </summary>
        private int currentDirectoryCluster;
        /// <summary>
        /// Ссылка на массив файлов и каталогов
        /// </summary>
        private object[] directoriesAndFiles;
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
        /// Создает каталог
        /// </summary>
        /// <returns></returns>
        public override bool Execute()
        {
            
            Directory currentDirectory;
            int clusterForDirectory = FAT.GetNextFreeBlock();
            if (clusterForDirectory != GlobalConstants.EOC)
            {
                if (directoriesAndFiles[currentDirectoryCluster] == null)
                {
                    return false;
                }
                currentDirectory = (Directory)directoriesAndFiles[currentDirectoryCluster];
                CatalogEntry catalogEntry = new CatalogEntry(attributes, 0, clusterForDirectory, name, "");
                if (!currentDirectory.IsThereFreeSpace(currentDirectory.LastUsedClusterNumber))
                {
                    int cluster = FAT.GetNextFreeBlock();
                    if (cluster == GlobalConstants.EOC)
                    {
                        return false;
                    }
                    currentDirectory.Add(clusterSize, cluster);
                }                    
                currentDirectory.Search(currentDirectory.LastUsedClusterNumber).Add(catalogEntry);
                //
                // ниже костыль
                //
                Directory directoryToAdd = new Directory(catalogEntry);
                //
                // выше костыль
                //
                directoryToAdd.Add(clusterSize, clusterForDirectory);
                CreateDotFile dotFile = new CreateDotFile(fileSystem, clusterForDirectory);
                CreateDoubleDotFile doubleDotFile = new CreateDoubleDotFile(fileSystem, clusterForDirectory, currentDirectoryCluster);
                dotFile.Execute();
                doubleDotFile.Execute();
                directoriesAndFiles[clusterForDirectory] = directoryToAdd;
                return true;
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
        /// <param name="fileSystem">ссылка на файловую систему</param>
        /// <param name="currentDirectoryCluster">номер первого кластера директории родителя</param>
        public CreateDirectory(int clusterSize, string directoryName, bool hidden, bool system, ref FileSystem fileSystem, int currentDirectoryCluster)
        {
            this.fileSystem = fileSystem;
            attributes = new Attributes(true, hidden, system, false, true, false);
            FAT = fileSystem.FAT;
            name = directoryName;
            this.clusterSize = clusterSize;
            this.currentDirectoryCluster = currentDirectoryCluster;
            directoriesAndFiles = fileSystem.directoriesAndFiles;
        }
    }
}
