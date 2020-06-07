using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands.FileCommands
{
    /// <summary>
    /// Читает содержимое файла в специальный список в файловой системе
    /// </summary>
    public class ReadFile : Command
    {
        public FileSystem FileSystem { get; set; }

        internal override bool Execute()
        {
            if (FileSystem.CurrentFile == null || FileSystem.directoriesAndFiles[FileSystem.CurrentFile.FirstBlockNumber] == null)
            {
                return false;
            }
            File file = (File)FileSystem.directoriesAndFiles[FileSystem.CurrentFile.FirstBlockNumber];
            int[] clusters = FileSystem.FAT.GetFileBlocks(file.FirstClusterNumber);
            FileSystem.FileContent.Clear();
            for (int i = 0; i < clusters.Length; i++)
            {
                FileSystem.FileContent.Add(new string(file.Search(clusters[i]).Block));
            }
            FileSystem.CurrentFile.LastAccessDate.SetCurrentDate();
            return true;
        }
        /// <summary>
        /// Создает команду "Прочитать файл"
        /// </summary>
        /// <param name="fileSystem">ссылка на файловую систему</param>
        public ReadFile(FileSystem fileSystem)
        {
            FileSystem = fileSystem;
        }
    }
}
