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
        /// Ссылка на файловую систему
        /// </summary>
        public FileSystem FileSystem { get; set; }
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

        internal override bool Execute()
        {
            File file = new File();
            int clusterForFile = FileSystem.FAT.GetNextFreeBlock();
            if (clusterForFile != GlobalConstants.EOC)
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
                    CatalogEntry catalogEntry = new CatalogEntry(attributes, 0, clusterForFile, name, extension);
                    if (directory.AddEntry(catalogEntry))
                    {
                        FileSystem.directoriesAndFiles[directoryCluster] = directory;
                        file.Add(FileSystem.ClusterSize, clusterForFile);
                        FileSystem.directoriesAndFiles[clusterForFile] = file;
                        return true;
                    }
                }
                else
                {
                    int clusterForDirectory = FileSystem.FAT.GetNextFreeBlock(directory.FirstClusterNumber);
                    if (clusterForDirectory != GlobalConstants.EOC)
                    {
                        directory.Add(FileSystem.ClusterSize / 32, clusterForDirectory);   // потому что размер каталожной записи типо 32 байта
                        CatalogEntry catalogEntry = new CatalogEntry(attributes, 0, clusterForFile, name, extension);
                        if (directory.AddEntry(catalogEntry))
                        {
                            FileSystem.directoriesAndFiles[directoryCluster] = directory;
                            FileSystem.directoriesAndFiles[clusterForFile] = file;
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
        public CreateFile(string name, string extension, bool readOnly, bool system, bool hide, ref FileSystem fileSystem)
        {
            this.name = name;
            this.extension = extension;           
            attributes = new Attributes(readOnly, hide, system, false, false, false);
            FileSystem = fileSystem;
            this.directoryCluster = FileSystem.CurrentDirectory.FirstBlockNumber;
        }
    }
}
