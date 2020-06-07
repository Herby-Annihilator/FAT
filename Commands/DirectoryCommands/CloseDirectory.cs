using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands.DirectoryCommands
{
    /// <summary>
    /// Закрывает каталог
    /// </summary>
    public class CloseDirectory : Command
    {
        /// <summary>
        /// Ссылка на файловую систему
        /// </summary>
        public FileSystem FileSystem { get; set; }
        internal override bool Execute()
        {
            if (FileSystem.CurrentDirectory == FileSystem.RootDirectoryCatalog || FileSystem.directoriesAndFiles[FileSystem.CurrentDirectory.FirstBlockNumber] == null)
            {
                return false;
            }
            Directory currentDirectory = (Directory)FileSystem.directoriesAndFiles[FileSystem.CurrentDirectory.FirstBlockNumber];
            CatalogEntry doubleDotFile = currentDirectory.FindSubDirectory("..", FileSystem.FAT.GetFileBlocks(FileSystem.CurrentDirectory.FirstBlockNumber));
            if (FileSystem.directoriesAndFiles[doubleDotFile.FirstBlockNumber] == null)
            {
                return false;
            }
            currentDirectory = (Directory)FileSystem.directoriesAndFiles[doubleDotFile.FirstBlockNumber];
            FileSystem.CurrentDirectory = currentDirectory.CatalogEntry;
            FileSystem.CurrentDirectory.LastAccessDate.SetCurrentDate();
            return true;
        }
        /// <summary>
        /// Строит команду "Закрыть каталог"
        /// </summary>
        /// <param name="fileSystem">ссылка на файловую систему</param>
        public CloseDirectory(FileSystem fileSystem)
        {
            FileSystem = fileSystem;
        }
    }
}
