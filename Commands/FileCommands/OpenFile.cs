using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands.FileCommands
{
    /// <summary>
    /// Открывает файл из текущей директории (обновляет ссылки в файловой системе)
    /// </summary>
    public class OpenFile : Command
    {
        /// <summary>
        /// Ссылка на файловую систему
        /// </summary>
        public FileSystem FileSystem { get; set; }
        /// <summary>
        /// имя файла
        /// </summary>
        private string fileName;
        /// <summary>
        /// расширение файла
        /// </summary>
        private string fileExt;
        internal override bool Execute()
        {
            if (FileSystem.CurrentDirectory == null || FileSystem.directoriesAndFiles[FileSystem.CurrentDirectory.FirstBlockNumber] == null)
            {
                return false;
            }
            Directory directory = (Directory)FileSystem.directoriesAndFiles[FileSystem.CurrentDirectory.FirstBlockNumber];
            CatalogEntry file = directory.FindFile(fileName, fileExt, FileSystem.FAT.GetFileBlocks(directory.FirstClusterNumber));
            if (file != null)
            {
                FileSystem.CurrentFile = file;
                FileSystem.CurrentFile.LastAccessDate.SetCurrentDate();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Строит команду "Открыть файл"
        /// </summary>
        /// <param name="name">имя файла</param>
        /// <param name="extension">расширение файла</param>
        /// <param name="fileSystem">ссылка на файловую систему</param>
        public OpenFile(string name, string extension, FileSystem fileSystem)
        {
            FileSystem = fileSystem;
            fileName = name;
            fileExt = extension;
        }
    }
}
