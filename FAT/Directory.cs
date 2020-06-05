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
