﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable.FAT
{
    internal class Directory : TemplateFile<CatalogEntry>
    {
        //public delegate bool DesiredFileOrDirectory(string nameAndExtension, string desiredName); 

        /// <summary>
        /// Каталожная запись этого каталога (костыль, ну а что поделать)
        /// </summary>
        public CatalogEntry CatalogEntry { get; set; }
        /// <summary>
        /// Возвращает запись о каталоге, если находит его в текущей директории, иначе вернет null
        /// </summary>
        /// <param name="name">имя каталога (часть абсолютного имени, ограниченная слешами)</param>
        /// <param name="clustersWhereFindOut">массив кластеров, принадлежащий этому каталогу</param>
        /// <returns></returns>
        public CatalogEntry FindSubDirectory(string name, int[] clustersWhereFindOut)
        {
            CatalogEntry catalogEntry = null;
            Cluster<CatalogEntry> cluster;
            for (int i = 0; i < clustersWhereFindOut.Length; i++)
            {
                cluster = Search(clustersWhereFindOut[i]);
                for (int j = 0; j < cluster.Block.Length; j++)
                {
                    if (cluster.Block[j] != null)
                    {
                        if (cluster.Block[j].Name == name.ToUpper())
                        {
                            catalogEntry = cluster.Block[j];
                            break;
                        }
                    }
                }
                if (catalogEntry != null)
                {
                    break;
                }
            }
            
            return catalogEntry;
        }
        /// <summary>
        /// Находит файл в текущем каталоге
        /// </summary>
        /// <param name="name">имя файла</param>
        /// <param name="ext">расширение файла</param>
        /// <param name="clusters">массив кластеров, в которых располагается данная директория</param>
        /// <returns></returns>
        public CatalogEntry FindFile(string name, string ext, int[] clusters)
        {
            CatalogEntry file = null;
            Cluster<CatalogEntry> cluster;
            for (int j = 0; j < clusters.Length; j++)
            {
                cluster = Search(clusters[j]);
                for (int i = 0; i < cluster.Block.Length; i++)
                {
                    if (cluster.Block[i] != null)
                    {
                        if (cluster.Block[i].Name == name.ToUpper() && cluster.Block[i].Extension == ext.ToUpper())
                        {
                            file = cluster.Block[i];
                            break;
                        }
                    }
                }
                if (file != null)
                {
                    break;
                }
            }
            return file;
        }
        public Directory(CatalogEntry catalogEntry) : base()
        {
            CatalogEntry = catalogEntry;
            Add(CatalogEntry.FileSize / 32, CatalogEntry.FirstBlockNumber);
        }
        /// <summary>
        /// Узнает, есть ли в кластере свободное место под каталожную запись.
        /// Если есть, то вернет true, иначе false.
        /// </summary>
        /// <param name="clusterNumber">кластер, в котором нужно произвести поиск</param>
        /// <returns></returns>
        public override bool IsThereFreeSpace(int clusterNumber)
        {
            Cluster<CatalogEntry> cluster = Search(LastUsedClusterNumber);
            for (int i = 0; i < cluster.Block.Length; i++)
            {
                if (cluster.Block[i] == null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
