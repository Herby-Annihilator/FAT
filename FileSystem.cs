using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.Commands;
using FileAllocationTable.FAT;

namespace FileAllocationTable
{
    /// <summary>
    /// Файловая система
    /// </summary>
    public class FileSystem
    {
        /// <summary>
        /// Размер диска в байтах
        /// </summary>
        public int HardDriverSize { get; set; }
        /// <summary>
        /// Размер кластера в байтах
        /// </summary>
        public int ClusterSize { get; set; }
        /// <summary>
        /// Таблица FAT в этой системе
        /// </summary>
        public FAT32 FAT { get; set; }
        /// <summary>
        /// Текущий используемый каталог
        /// </summary>
        public CatalogEntry CurrentCatalogEntry { get; set; } = null;
        /// <summary>
        /// Корневой каталог
        /// </summary>
        public CatalogEntry RootDirectoryCatalog { get; set; }
        /// <summary>
        /// Этот объект (текущая директория) должен строиться только тогда, когда он действительно нужен 
        /// </summary>
        public Directory Directory { get; set; }
        /// <summary>
        /// Этот объект (текущий файл) должен строиться только тогда, когда он действительно нужен
        /// </summary>
        public File File { get; set; }
        public bool ExecuteCommand(Command command)
        {
            return command.Execute();
        }
    }
}
