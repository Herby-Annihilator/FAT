using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands.FileCommands
{
    /// <summary>
    /// Удаляет файл
    /// </summary>
    public class RemoveFile : Command
    {
        public FileSystem FileSystem { get; private set; }
        private string fileName;
        private string ext;
        internal override bool Execute()
        {
            OpenFile openFile = new OpenFile(fileName, ext, FileSystem);
            if (!openFile.Execute())
            {
                return false;
            }
            else
            {
                //
                // вот сейчас я буду делать пакости, так делать нельзя, ибо утечка памяти
                //
                FileSystem.directoriesAndFiles[FileSystem.CurrentFile.FirstBlockNumber] = null;   // просто занулил нахер дерево, так нельзя делать
                FileSystem.FAT.FreeBlocks(FileSystem.CurrentFile.FirstBlockNumber);
                if (FileSystem.directoriesAndFiles[FileSystem.CurrentDirectory.FirstBlockNumber] == null)
                {
                    return false;
                }
                Directory directory = (Directory)FileSystem.directoriesAndFiles[FileSystem.CurrentDirectory.FirstBlockNumber];

                int[] clusters = FileSystem.FAT.GetFileBlocks(FileSystem.CurrentDirectory.FirstBlockNumber);
                if (!directory.RemoveCatalogEntry(FileSystem.CurrentFile.FirstBlockNumber, clusters))
                {
                    return false;
                }

                FileSystem.directoriesAndFiles[FileSystem.CurrentDirectory.FirstBlockNumber] = directory;
                CloseFile closeFile = new CloseFile(FileSystem);
                return closeFile.Execute();
            }
        }
        /// <summary>
        /// Строит команду "Удалить файл"
        /// </summary>
        /// <param name="fileSystem">ссылка на файловую систему</param>
        /// <param name="fileName">имя файла</param>
        /// <param name="extension">расширение файла</param>
        public RemoveFile(FileSystem fileSystem, string fileName, string extension)
        {
            this.fileName = fileName;
            FileSystem = fileSystem;
            ext = extension;
        }
    }
}
