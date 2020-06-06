using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable.Commands.FileCommands
{
    /// <summary>
    /// Закрыавет текущий файл
    /// </summary>
    public class CloseFile : Command
    {
        /// <summary>
        /// Ссылка на файловую систему
        /// </summary>
        public FileSystem FileSystem { get; set; }
        public override bool Execute()
        {
            FileSystem.CurrentFile = null;
            return true;
        }
        /// <summary>
        /// Строит команду "Закрыть файл"
        /// </summary>
        /// <param name="fileSystem">ссылка на файловую систему</param>
        public CloseFile(FileSystem fileSystem)
        {
            FileSystem = fileSystem;
        }
    }
}
