using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable.Commands
{
    public abstract class Command
    {
        /// <summary>
        /// Метод выполнения команды
        /// </summary>
        public abstract bool Execute();
    }
}
