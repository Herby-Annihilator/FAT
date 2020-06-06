using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands.FileCommands
{
    /// <summary>
    /// Создать файл
    /// </summary>
    public class CreateFile : Command
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        protected string name;
        /// <summary>
        /// Расширение файла
        /// </summary>
        protected string extension;
        /// <summary>
        /// Атрибуты файла
        /// </summary>
        protected Attributes attributes;
        /// <summary>
        /// Нчальный номер кластера директории, в которой создается файл
        /// </summary>
        protected int directoryCluster;
        /// <summary>
        /// Размер кластера в байтах
        /// </summary>
        protected int clusterSize;
        /// <summary>
        /// Таблица FAT
        /// </summary>
        public FAT32 FAT { get; set; }
        /// <summary>
        /// Массив директорий и файлов
        /// </summary>
        protected object[] directoriesAndFiles;

        public override bool Execute()
        {
            File file = new File();
            int clusterForFile = FAT.GetNextFreeBlock();
            if (clusterForFile != GlobalConstants.EOC)
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
                    CatalogEntry catalogEntry = new CatalogEntry(attributes, 0, clusterForFile, name, extension);
                    if (directory.Search(directory.LastUsedClusterNumber).Add(catalogEntry))
                    {
                        directoriesAndFiles[directoryCluster] = directory;
                        file.Add(clusterSize, clusterForFile);
                        directoriesAndFiles[clusterForFile] = file;
                        return true;
                    }
                }
                else
                {
                    int clusterForDirectory = FAT.GetNextFreeBlock(directory.FirstClusterNumber);
                    if (clusterForDirectory != GlobalConstants.EOC)
                    {
                        directory.Add(clusterSize / 32, clusterForDirectory);   // потому что размер каталожной записи типо 32 байта
                        CatalogEntry catalogEntry = new CatalogEntry(attributes, 0, clusterForFile, name, extension);
                        if (directory.Search(directory.LastUsedClusterNumber).Add(catalogEntry))
                        {
                            directoriesAndFiles[directoryCluster] = directory;
                            directoriesAndFiles[clusterForFile] = file;
                            return true;
                        }
                        
                    }
                }                
            }
            return false;
        }
        /// <summary>
        /// Создает экземпляр команды "Создать файл"
        /// </summary>
        /// <param name="name">имя файла</param>
        /// <param name="extension">расширение файла</param>
        /// <param name="readOnly">будет ли файл только для чтения</param>
        /// <param name="system">будет ли файл системным</param>
        /// <param name="hide">будет ли файл скрытым</param>
        /// <param name="fileSystem">файловая система</param>
        /// <param name="directoryCluster">начальный кластер, в котором находится директория, в которой будет создаваться файл</param>
        public CreateFile(string name, string extension, bool readOnly, bool system, bool hide, ref FileSystem fileSystem, int directoryCluster)
        {
            this.name = name;
            this.extension = extension;
            this.directoryCluster = directoryCluster;
            attributes = new Attributes(readOnly, hide, system, false, false, false);
            FAT = fileSystem.FAT;
            directoriesAndFiles = fileSystem.directoriesAndFiles;
            clusterSize = fileSystem.ClusterSize;
        }
    }
}
