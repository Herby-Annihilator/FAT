using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands.FileCommands
{
    /// <summary>
    /// Модифицировать файл (сначала открыть). В файловой системе должен быть готов список строк для записи в файл
    /// </summary>
    public class WriteToFile : Command
    {
        /// <summary>
        /// Ссылка на файловую систему
        /// </summary>
        public FileSystem FileSystem { get; set; }
        public override bool Execute()
        {
            if (FileSystem.CurrentFile == null || FileSystem.directoriesAndFiles[FileSystem.CurrentFile.FirstBlockNumber] == null)
            {
                return false;
            }
            File file = (File)FileSystem.directoriesAndFiles[FileSystem.CurrentFile.FirstBlockNumber];
            int[] clusters = FileSystem.FAT.GetFileBlocks(file.FirstClusterNumber);
            //
            // если нужно добавить еще кластеров
            //
            if (FileSystem.FileContent.Count < clusters.Length)   
            {
                int difference = FileSystem.FileContent.Count - clusters.Length;
                int[] newClusters = new int[difference];
                for (int i = 0; i < difference; i++)
                {
                    newClusters[i] = FileSystem.FAT.GetNextFreeBlock(clusters[0]);
                    if (newClusters[i] == GlobalConstants.EOC)
                    {
                        return false;
                    }
                    file.Add(FileSystem.ClusterSize, newClusters[i]);
                }
                // модифицировать clusters[]
                int[] clusters1 = new int[clusters.Length + difference];
                for (int i = 0; i < clusters.Length; i++)
                {
                    clusters1[i] = clusters[i];
                }
                int j = 0;
                for (int i = clusters.Length; i < clusters.Length + difference; i++, j++)
                {
                    clusters1[i] = newClusters[j];
                }
                clusters = clusters1;
            }
            for (int i = 0; i < FileSystem.FileContent.Count; i++)
            {
                file.Search(clusters[i]).Block = FileSystem.FileContent[i].ToCharArray();
            }
            FileSystem.directoriesAndFiles[FileSystem.CurrentFile.FirstBlockNumber] = file;  // потому что мы изменили файл (возможно, такое присвоение не обязательно)
            FileSystem.CurrentFile.LastDateRecorded.SetCurrentDate();
            FileSystem.CurrentFile.LastTimeRecorded.SetCurrentHours();
            return true;
        }
        /// <summary>
        /// Строит команду "Писать в файл"
        /// </summary>
        /// <param name="fileSystem">ссылка на файловую систему</param>
        public WriteToFile(FileSystem fileSystem)
        {
            FileSystem = fileSystem;
        }
    }
}
