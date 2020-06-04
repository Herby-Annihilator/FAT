using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.FAT;

namespace FileAllocationTable.Commands.FileCommands
{
    public class CreateFile : Command
    {
        private string name;
        private string extension;
        private Attributes attributes;
        public FAT32 FAT { get; set; }

        public Directory RootDirectory { get; set; }
        public override bool Execute()
        {
            throw new NotImplementedException();
        }
    }
}
