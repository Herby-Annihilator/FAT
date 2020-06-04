using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable.FAT
{
    public class TemplateFile<T>
    {
        /// <summary>
        /// Корень, начальный блок файла
        /// </summary>
        private FileNode<T> root;
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
                root = new FileNode<T>(blockSize, blockNumber);
            }
            else
            {
                FileNode<T> currentNode = root;
                while (true)
                {
                    if (blockNumber < currentNode.BlockNumber)
                    {
                        if (currentNode.LeftChild != null)
                        {
                            currentNode = currentNode.LeftChild;
                        }
                        else
                        {
                            currentNode.LeftChild = new FileNode<T>(blockSize, blockNumber);
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
                            currentNode.RightChild = new FileNode<T>(blockSize, blockNumber);
                            break;
                        }
                    }
                }
            }
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
                FileNode<T> deletedNode = root;
                FileNode<T> parentNode = root;
                while (true)
                {
                    if (key < deletedNode.BlockNumber)
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
                    else if (key > deletedNode.BlockNumber)
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
                    FileNode<T> minRightNode = FindMinNode(root.RightChild);
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
                    FileNode<T> minRightNode = FindMinNode(deletedNode.RightChild);
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
                    FileNode<T> minRightNode = FindMinNode(deletedNode.RightChild);
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
        private FileNode<T> FindMinNode(FileNode<T> root)
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
                FileNode<T> currentNode = root.LeftChild;
                FileNode<T> parentNode = root;
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
        public FileNode<T> Search(int key)
        {
            FileNode<T> toReturn = root;
            while (toReturn != null)
            {
                if (key < toReturn.BlockNumber)
                {
                    toReturn = toReturn.LeftChild;
                }
                else if (key > toReturn.BlockNumber)
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

    }
}
