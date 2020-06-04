using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands
{
    public class OpenDirectory : Command
    {
        private string fullName;
        public FAT32 FAT { get; set; }
        public Directory RootDirectory { get; set; }
        public override bool Execute()
        {
            string[] directories = fullName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            CatalogEntry currentCatalog = RootDirectory.FindSubDirectory(directories[0], RootDirectory.FirstClusterNumber);
            if (currentCatalog != null)
            {
                for (int i = 1; i < directories.Length; i++)
                {
                    currentCatalog = RootDirectory.FindSubDirectory(directories[i], currentCatalog.FirstBlockNumber);
                    if (currentCatalog == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public OpenDirectory(string fullName, ref FAT32 fat, ref Directory directory)
        {
            this.fullName = fullName;
            FAT = fat;
            RootDirectory = directory;
        }
    }
}
