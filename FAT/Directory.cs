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
