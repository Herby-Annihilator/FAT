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
        public  FileSystem FileSystem { get; set; }
        /// <summary>
        /// Атрибуты каталога
        /// </summary>
        private Attributes attributes;
        /// <summary>
        /// Имя каталога
        /// </summary>
        private string name;
        /// <summary>
        /// Создает каталог
        /// </summary>
        /// <returns></returns>
        internal override bool Execute()
        {
            
            Directory currentDirectory;
            int clusterForDirectory = FileSystem.FAT.GetNextFreeBlock();
            if (clusterForDirectory != GlobalConstants.EOC)
            {
                if (FileSystem.directoriesAndFiles[FileSystem.CurrentDirectory.FirstBlockNumber] == null)
                {
                    return false;
                }
                currentDirectory = (Directory)FileSystem.directoriesAndFiles[FileSystem.CurrentDirectory.FirstBlockNumber];
                CatalogEntry catalogEntry = new CatalogEntry(attributes, FileSystem.ClusterSize / 32, clusterForDirectory, name, "");
                if (!currentDirectory.IsThereFreeSpace(currentDirectory.LastUsedClusterNumber))
                {
                    int cluster = FileSystem.FAT.GetNextFreeBlock(currentDirectory.FirstClusterNumber);
                    if (cluster == GlobalConstants.EOC)
                    {
                        return false;
                    }
                    currentDirectory.Add(FileSystem.ClusterSize / 32, cluster);  // потому что размер каталожной записи типо 32 байта
                }                    
                currentDirectory.AddEntry(catalogEntry);
                //
                // ниже костыль
                //
                Directory directoryToAdd = new Directory(catalogEntry);
                //
                // выше костыль
                //
                //directoryToAdd.Add(FileSystem.ClusterSize / 32, clusterForDirectory);
                FileSystem.directoriesAndFiles[clusterForDirectory] = directoryToAdd;
                CreateDotFile dotFile = new CreateDotFile(FileSystem, clusterForDirectory);
                CreateDoubleDotFile doubleDotFile = new CreateDoubleDotFile(FileSystem, clusterForDirectory);
                dotFile.Execute();
                doubleDotFile.Execute();
                FileSystem.directoriesAndFiles[clusterForDirectory] = directoryToAdd;
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
        public CreateDirectory(string directoryName, bool hidden, bool system, FileSystem fileSystem)
        {
            FileSystem = fileSystem;
            attributes = new Attributes(true, hidden, system, false, true, false);
            name = directoryName;
        }
    }
}
