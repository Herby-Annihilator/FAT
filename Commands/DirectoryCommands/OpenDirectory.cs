using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands
{
    public class OpenDirectory : Command   // модифицируте поля файловой системы, чтобы можно было вызвать команду ReadDirectory
    {
        private int rootDirectoryClusterNumber;
        public FileSystem FileSystem { get; set; }

        private string fullName;
        private Directory RootDirectory { get; set; }
        public override bool Execute()
        {
            if (FileSystem.directoriesAndFiles[FileSystem.RootDirectoryCatalog.FirstBlockNumber] != null)
            {
                RootDirectory = (Directory)FileSystem.directoriesAndFiles[FileSystem.RootDirectoryCatalog.FirstBlockNumber];
                int[] clusters = FileSystem.FAT.GetFileBlocks(RootDirectory.FirstClusterNumber);
                string[] directories = fullName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                CatalogEntry currentDirectory = null;
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public OpenDirectory(string fullName, ref FileSystem fileSystem)
        {
            this.fullName = fullName;
            FileSystem = fileSystem;
        }
    }
}
