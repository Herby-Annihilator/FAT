using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands.FileCommands
{
    /// <summary>
    /// Создает файл "."
    /// </summary>
    public class CreateDotFile : CreateFile
    {
        public override bool Execute()
        {          
            Directory directory;
            if (directoriesAndFiles[directoryCluster] == null)
            {
                return false;
            }
            else
            {
                directory = (Directory)directoriesAndFiles[directoryCluster];
            }

            if (directory.IsThereFreeSpace(directory.LastUsedClusterNumber))
            {
                CatalogEntry catalogEntry = new CatalogEntry(attributes, 0, directoryCluster, name, extension);
                if (directory.Search(directory.LastUsedClusterNumber).Add(catalogEntry))
                {
                    directoriesAndFiles[directoryCluster] = directory;
                    return true;
                }
                    
            }
            else
            {
                int clusterForDirectory = FAT.GetNextFreeBlock(directory.FirstClusterNumber);
                if (clusterForDirectory != GlobalConstants.EOC)
                {
                    directory.Add(clusterSize, clusterForDirectory);
                    CatalogEntry catalogEntry = new CatalogEntry(attributes, 0, directoryCluster, name, extension);
                    if (directory.Search(directory.LastUsedClusterNumber).Add(catalogEntry))
                    {
                        directoriesAndFiles[directoryCluster] = directory;
                        return true;
                    }                       
                }
            }
        return false;

        }
        /// <summary>
        /// Создает команду "Создать файл ."
        /// </summary>
        /// <param name="fileSystem">файловая система</param>
        /// <param name="directoryCluster">стартовый номер кластера той директории, в которой будем делать этот файл</param>
        public CreateDotFile(FileSystem fileSystem, int directoryCluster) : base(".", "", true, true, true, ref fileSystem, directoryCluster)
        {
            
        }

    }
}
