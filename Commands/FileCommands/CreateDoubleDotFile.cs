using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands.FileCommands
{
    /// <summary>
    /// Создает файл ".."
    /// </summary>
    public class CreateDoubleDotFile : CreateFile
    {
        /// <summary>
        /// Номер родительской директории в FAT
        /// </summary>
        private int parentDirectoryCluster;
        /// <summary>
        /// Создает команду "Создать файл .."
        /// </summary>
        /// <param name="fileSystem">файловая система</param>
        /// <param name="directoryCluster">стартовый номер кластера той директории, в которой будем делать этот файл</param>
        /// <param name="parentDirectoryCluster">стартовый номер кластера директории-родителя</param>
        public CreateDoubleDotFile(FileSystem fileSystem, int directoryCluster, int parentDirectoryCluster) : base("..", "", true, true, true, ref fileSystem, directoryCluster)
        {
            this.parentDirectoryCluster = parentDirectoryCluster;
        }

        public override bool Execute()
        {
            Directory directory;
            if (FileSystem.directoriesAndFiles[directoryCluster] == null)
            {
                return false;
            }
            else
            {
                directory = (Directory)FileSystem.directoriesAndFiles[directoryCluster];
            }

            if (directory.IsThereFreeSpace(directory.LastUsedClusterNumber))
            {
                CatalogEntry catalogEntry = new CatalogEntry(attributes, 0, parentDirectoryCluster, name, extension);
                if (directory.Search(directory.LastUsedClusterNumber).Add(catalogEntry))
                {
                    FileSystem.directoriesAndFiles[directoryCluster] = directory;
                    return true;
                }

            }
            else
            {
                int clusterForDirectory = FileSystem.FAT.GetNextFreeBlock(directory.FirstClusterNumber);
                if (clusterForDirectory != GlobalConstants.EOC)
                {
                    directory.Add(FileSystem.ClusterSize / 32, clusterForDirectory);
                    CatalogEntry catalogEntry = new CatalogEntry(attributes, 0, parentDirectoryCluster, name, extension);
                    if (directory.Search(directory.LastUsedClusterNumber).Add(catalogEntry))
                    {
                        FileSystem.directoriesAndFiles[directoryCluster] = directory;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
