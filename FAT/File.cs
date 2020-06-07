using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable.FAT
{
    internal class File : TemplateFile<char>
    {
        
        public override bool IsThereFreeSpace(int clusterNumber)
        {
            throw new Exception();
        }
    }
}
