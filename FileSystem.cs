using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAllocationTable.Commands;
using FileAllocationTable.Commands.DirectoryCommands;
using FileAllocationTable.Commands.FileCommands;
using FileAllocationTable.FAT;

namespace FileAllocationTable
{
    /// <summary>
    /// Файловая система
    /// </summary>
    public class FileSystem
    {
        /// <summary>
        /// Это будет массив файлов и каталогов - "отражение" таблицы FAT
        /// </summary>
        internal object[] directoriesAndFiles;
        /// <summary>
        /// Размер диска в байтах
        /// </summary>
        public int HardDriverSize { get; set; }
        /// <summary>
        /// Размер кластера в байтах
        /// </summary>
        public int ClusterSize { get; internal set; }
        /// <summary>
        /// Таблица FAT в этой системе
        /// </summary>
        internal FAT32 FAT { get; set; }
        /// <summary>
        /// Корневой каталог
        /// </summary>
        internal CatalogEntry RootDirectoryCatalog { get; set; }
        public bool ExecuteCommand(Command command)
        {
            return command.Execute();
        }
        /// <summary>
        /// Список файлов и каталогов, находящихся в данном каталоге
        /// </summary>
        public List<string> FilesAndDirectoriesInDirectory { get; set; } = new List<string>();
        /// <summary>
        /// Текущий используемы каталог
        /// </summary>
        internal CatalogEntry CurrentDirectory { get; set; } = null;
        /// <summary>
        /// Текущий используемый каталог
        /// </summary>
        internal CatalogEntry CurrentFile { get; set; } = null;
        /// <summary>
        /// Содержимое файла - длина одной строки = не больше размера кластера в байтах
        /// </summary>
        public List<string> FileContent { get; set; } = new List<string>();
        /// <summary>
        /// "Инициализирует" файловую систему
        /// </summary>
        /// <param name="hardDriverSize">размер диска в байтах</param>
        public FileSystem(int hardDriverSize)
        {
            HardDriverSize = hardDriverSize;
            ClusterSize = 4096;
            FAT = new FAT32(HardDriverSize / 4096);
            directoriesAndFiles = new object[FAT.TableSize];
            //
            // Создаем корневой каталог
            //
            int clusterForRoot = FAT.GetNextFreeBlock();
            Attributes rootAttributes = new Attributes(false, false, true, false, true, false);
            RootDirectoryCatalog = new CatalogEntry(rootAttributes, 0, clusterForRoot, "\\", "");
            directoriesAndFiles[clusterForRoot] = new Directory(RootDirectoryCatalog);
            CurrentDirectory = RootDirectoryCatalog;
            CreateDotFile dotFile = new CreateDotFile(this, clusterForRoot);
            dotFile.Execute();
        }
    }
}
