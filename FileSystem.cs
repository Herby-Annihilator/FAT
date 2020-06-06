﻿using System;
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
        /// Это будет массив файлов и каталогов - "отражение" таблицы FAT
        /// </summary>
        public object[] directoriesAndFiles;
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
        /// Корневой каталог
        /// </summary>
        public CatalogEntry RootDirectoryCatalog { get; set; }
        /// <summary>
        /// Этот объект (текущий файл) должен строиться только тогда, когда он действительно нужен
        /// </summary>
        public File File { get; set; }
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
        public CatalogEntry CurrentDirectory { get; set; } = null;
        /// <summary>
        /// Текущий используемый каталог
        /// </summary>
        public CatalogEntry CurrentFile { get; set; } = null;
        /// <summary>
        /// Содержимое файла - длина одной строки = не больше размера кластера в байтах
        /// </summary>
        public List<string> FileContent { get; set; } = new List<string>();
    }
}
