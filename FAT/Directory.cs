using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable.FAT
{
    public class Directory : TemplateFile<CatalogEntry>
    {
        /// <summary>
        /// Создает поддиректорию
        /// </summary>
        /// <param name="name">имя подкаталога</param>
        /// <param name="attributes">его атрибуты</param>
        /// <param name="clusterNumberInFATforNewDirectory">номер кластера для каталога</param>
        /// <returns></returns>
        public bool CreateSubdirectory(string name, Attributes attributes, int clusterNumberInFATforNewDirectory)
        {
            Cluster<CatalogEntry> cluster = Search(LastUsedClusterNumber);
            CatalogEntry toAdd = new CatalogEntry();
            toAdd.Attributes = attributes;
            toAdd.DateOfCreation.SetCurrentDate();
            toAdd.Name = name;
            toAdd.Extension = "";
            toAdd.FileSize = 0;
            toAdd.FirstBlockNumber = clusterNumberInFATforNewDirectory;
            toAdd.LastAccessDate = toAdd.DateOfCreation;
            toAdd.LastDateRecorded = toAdd.DateOfCreation;
            toAdd.TimeOfCreation.SetCurrentTime();
            toAdd.LastTimeRecorded = toAdd.TimeOfCreation;
            return cluster.Add(toAdd);
        }
        /// <summary>
        /// Возвращает запись о каталоге, если находит его в указанном кластере, иначе вернет null
        /// </summary>
        /// <param name="name">имя каталога (часть абсолютного имени, ограниченная слешами)</param>
        /// <param name="currentCluster">кластер, в котором ведется поиск</param>
        /// <returns></returns>
        public CatalogEntry FindSubDirectory(string name, int currentCluster)
        {
            CatalogEntry catalogEntry = null;
            Cluster<CatalogEntry> cluster = Search(currentCluster);
            for (int i = 0; i < cluster.Block.Length; i++)
            {
                if (cluster.Block[i].Name == name.ToUpper())
                {
                    catalogEntry = cluster.Block[i];
                    break;
                }
            }
            return catalogEntry;
        }
        public Directory() : base()
        {
            
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
