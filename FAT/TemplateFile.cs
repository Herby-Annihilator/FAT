using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable.FAT
{
    internal abstract class TemplateFile<T>
    {
        /// <summary>
        /// Номер первого кластера
        /// </summary>
        public int FirstClusterNumber { get; protected set; }
        /// <summary>
        /// Номер последенего добавленного кластера
        /// </summary>
        public int LastUsedClusterNumber { get; protected set; }
        /// <summary>
        /// Корень, начальный блок файла
        /// </summary>
        private Cluster<T> root;
        /// <summary>
        ///  Текущее кол-во блоков в файле
        /// </summary>
        public int BlockCount { get; set; }
        /// <summary>
        /// Добавляет новый блок с указанным номером и размером
        /// </summary>
        /// <param name="blockSize">размер блока в байтах</param>
        /// <param name="blockNumber">номер блока в FAT</param>
        public void Add(int blockSize, int blockNumber)
        {
            if (root == null)
            {
                root = new Cluster<T>(blockSize, blockNumber);
                FirstClusterNumber = blockNumber;
            }
            else
            {
                Cluster<T> currentNode = root;
                while (true)
                {
                    if (blockNumber < currentNode.ClusterNumber)
                    {
                        if (currentNode.LeftChild != null)
                        {
                            currentNode = currentNode.LeftChild;
                        }
                        else
                        {
                            currentNode.LeftChild = new Cluster<T>(blockSize, blockNumber);
                            break;
                        }
                    }
                    else
                    {
                        if (currentNode.RightChild != null)
                        {
                            currentNode = currentNode.RightChild;
                        }
                        else
                        {
                            currentNode.RightChild = new Cluster<T>(blockSize, blockNumber);
                            break;
                        }
                    }
                }
            }
            LastUsedClusterNumber = blockNumber;
            BlockCount++;
            return;
        }
        /// <summary>
        /// Удаляет узел с указанным ключом (номер блока)
        /// </summary>
        /// <param name="key">блок для удаления (ключ)</param>
        public void Remove(int key)
        {
            if (root != null)
            {
                Cluster<T> deletedNode = root;
                Cluster<T> parentNode = root;
                while (true)
                {
                    if (key < deletedNode.ClusterNumber)
                    {
                        if (deletedNode.LeftChild != null)
                        {
                            parentNode = deletedNode;
                            deletedNode = deletedNode.LeftChild;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (key > deletedNode.ClusterNumber)
                    {
                        if (deletedNode.RightChild != null)
                        {
                            parentNode = deletedNode;
                            deletedNode = deletedNode.RightChild;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (deletedNode == parentNode)
                {
                    // значит удаляем корень
                    Cluster<T> minRightNode = FindMinNode(root.RightChild);
                    if (minRightNode == null)
                    {
                        root = root.LeftChild;
                    }
                    else if (root.RightChild == minRightNode)
                    {
                        minRightNode.LeftChild = root.LeftChild;
                        root = minRightNode;
                    }
                    else
                    {
                        minRightNode.LeftChild = root.LeftChild;
                        minRightNode.RightChild = root.RightChild;
                        root = minRightNode;
                    }
                }
                else if (deletedNode == parentNode.LeftChild)
                {
                    Cluster<T> minRightNode = FindMinNode(deletedNode.RightChild);
                    if (minRightNode == null)
                    {
                        parentNode.LeftChild = deletedNode.LeftChild;
                    }
                    else if (minRightNode == deletedNode.RightChild)
                    {
                        minRightNode.LeftChild = deletedNode.LeftChild;
                        parentNode.LeftChild = minRightNode;
                    }
                    else
                    {
                        minRightNode.LeftChild = deletedNode.LeftChild;
                        minRightNode.RightChild = deletedNode.RightChild;
                        parentNode.LeftChild = minRightNode;
                    }
                }
                else
                {
                    Cluster<T> minRightNode = FindMinNode(deletedNode.RightChild);
                    if (minRightNode == null)
                    {
                        parentNode.RightChild = deletedNode.LeftChild;
                    }
                    else if (minRightNode == deletedNode.RightChild)
                    {
                        minRightNode.LeftChild = deletedNode.LeftChild;
                        parentNode.RightChild = minRightNode;
                    }
                    else
                    {
                        minRightNode.LeftChild = deletedNode.LeftChild;
                        minRightNode.RightChild = deletedNode.RightChild;
                        parentNode.RightChild = minRightNode;
                    }
                }
                BlockCount--;
            }
            return;
        }
        /// <summary>
        /// Находит минимальный элемент в указанном поддереве (начиная с указанного узла) и возвращает его, уадаляя 
        /// из начального местоположения. Если передадите null получите null
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private Cluster<T> FindMinNode(Cluster<T> root)
        {
            if (root == null)
            {
                return null;
            }
            else if (root.LeftChild == null)
            {
                return root;
            }
            else
            {
                Cluster<T> currentNode = root.LeftChild;
                Cluster<T> parentNode = root;
                while (true)
                {
                    if (currentNode.LeftChild == null)
                    {
                        parentNode.LeftChild = currentNode.RightChild;
                        currentNode.RightChild = null;
                        break;
                    }
                    else
                    {
                        parentNode = currentNode;
                        currentNode = currentNode.LeftChild;
                    }
                }
                return currentNode;
            }
        }
        /// <summary>
        /// Вернет узел по указанному ключу. Если такого нет, то вернет null, если в файле ничего нет, то вернет null
        /// </summary>
        /// <param name="key">ключ</param>
        /// <returns></returns>
        public Cluster<T> Search(int key)
        {
            Cluster<T> toReturn = root;
            while (toReturn != null)
            {
                if (key < toReturn.ClusterNumber)
                {
                    toReturn = toReturn.LeftChild;
                }
                else if (key > toReturn.ClusterNumber)
                {
                    toReturn = toReturn.RightChild;
                }
                else
                {
                    break;
                }
            }
            return toReturn;
        }
        /// <summary>
        /// Создает файл размера 0
        /// </summary>
        public TemplateFile()
        {
            root = null;
            BlockCount = 0;
        }
        /// <summary>
        /// Узнает, есть ли в кластере свободное место под данный тип T.
        /// Если есть, то вернет true, иначе false.
        /// </summary>
        /// <param name="clusterNumber">кластер, в котором нужно произвести поиск</param>
        public abstract bool IsThereFreeSpace(int clusterNumber);
    }
}
