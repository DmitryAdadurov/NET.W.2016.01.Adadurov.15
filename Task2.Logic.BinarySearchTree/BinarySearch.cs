using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic.BinarySearchTree
{
    public class BinarySearch<T> : IEnumerable<T>, IEnumerable
    {
        public Node<T> Root { get; set; }

        public BinarySearch(Node<T> root)
        {
            Root = root;
        }

        public IEnumerator<T> GetEnumerator()
        {
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Node<T>
    {
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }
        public T Value { get; set; }
    }
}
