using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands
{
    /// <summary>
    /// Открыть директорию
    /// </summary>
    public class OpenDirectory : Command   // модифицируте поля файловой системы, чтобы можно было вызвать команду ReadDirectory
    {
        /// <summary>
        /// Ссылка на файловую систему
        /// </summary>
        public FileSystem FileSystem { get; set; }
        /// <summary>
        /// Путь до искомой директорией, начиная с текущей(работчей)
        /// </summary>
        private string fullName;   // не обязательно абсолютный путь
        /// <summary>
        /// Директория, с которой стартует поиск
        /// </summary>
        private Directory StartDirectory { get; set; }
        internal override bool Execute()
        {
            if (FileSystem.directoriesAndFiles[FileSystem.CurrentDirectory.FirstBlockNumber] != null)
            {
                if (!FileSystem.CurrentDirectory.Attributes.Subdirectory)
                {
                    return false;
                }
                StartDirectory = (Directory)FileSystem.directoriesAndFiles[FileSystem.CurrentDirectory.FirstBlockNumber];
                int[] clusters = FileSystem.FAT.GetFileBlocks(StartDirectory.FirstClusterNumber);
                string[] directories = fullName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                CatalogEntry currentDirectoryEntry = FileSystem.CurrentDirectory;
                for (int i = 0; i < directories.Length; i++)
                {
                    currentDirectoryEntry = StartDirectory.FindSubDirectory(directories[i], clusters);
                    if (currentDirectoryEntry == null || FileSystem.directoriesAndFiles[currentDirectoryEntry.FirstBlockNumber] == null)
                    {
                        return false;
                    }
                    StartDirectory = (Directory)FileSystem.directoriesAndFiles[currentDirectoryEntry.FirstBlockNumber];
                    clusters = FileSystem.FAT.GetFileBlocks(StartDirectory.FirstClusterNumber);
                }
                FileSystem.CurrentDirectory = currentDirectoryEntry;
                FileSystem.CurrentDirectory.LastAccessDate.SetCurrentDate();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Строит команду "Открыть директорию"
        /// </summary>
        /// <param name="fullName">путь до директории, начиная с работчей(текущей)</param>
        /// <param name="fileSystem">ссылка на файловую систему</param>
        public OpenDirectory(string fullName, ref FileSystem fileSystem)
        {
            this.fullName = fullName;
            FileSystem = fileSystem;
        }
    }
}
