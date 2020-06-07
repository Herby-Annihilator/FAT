using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands.DirectoryCommands
{
    /// <summary>
    /// Прочитать директорию (вывести ее)
    /// </summary>
    public class ReadDirectory : Command
    {
        /// <summary>
        /// Ссылка на файловую систему
        /// </summary>
        private FileSystem FileSystem { get; set; }
        /// <summary>
        /// Текущая директория
        /// </summary>
        private Directory currentDirectory;
        /// <summary>
        /// Таблица FAT
        /// </summary>
        private FAT32 fat;
        public override bool Execute()
        {
            int[] directoryClusters = fat.GetFileBlocks(currentDirectory.FirstClusterNumber);
            FileSystem.FilesAndDirectoriesInDirectory.Clear();
            for (int i = 0; i < directoryClusters.Length; i++)
            {
                Cluster<CatalogEntry> cluster = currentDirectory.Search(i);
                if (cluster == null)
                {
                    return false;
                }
                for (int j = 0; j < cluster.Block.Length; j++)
                {
                    if (cluster.Block[j] != null)
                    {
                        if (!cluster.Block[i].Attributes.Hidden)
                        {
                            FileSystem.FilesAndDirectoriesInDirectory.Add(cluster.Block[j].Name + cluster.Block[j].Extension);
                        }                      
                    }
                }
            }
            FileSystem.CurrentDirectory.LastAccessDate.SetCurrentDate();
            return true;
        }
        /// <summary>
        /// Создаст команду "Прочитать директорию"
        /// </summary>
        /// <param name="fileSystem">ссылка на файловую систему</param>
        public ReadDirectory(FileSystem fileSystem)
        {
            FileSystem = fileSystem;
            currentDirectory = (Directory)FileSystem.directoriesAndFiles[FileSystem.CurrentDirectory.FirstBlockNumber];
            fat = FileSystem.FAT;
        }
    }
}
