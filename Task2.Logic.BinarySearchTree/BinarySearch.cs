using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic.BinarySearchTree
{
    public class BinarySearch<T> : IEnumerable<T>, IEnumerable where T : IComparable<T>
    {
        private IComparer<T> comparer;

        public Node<T> Root { get; set; }

        public BinarySearch(IEnumerable<T> values) : this(values, Comparer<T>.Default)
        {
        }

        public BinarySearch(IEnumerable<T> values, IComparer<T> comparer)
        {

            this.comparer = comparer;
            foreach (var item in values)
            {
                Root = Add(Root, item);
            }
        }

        public void Insert(T value)
        {
            Add(Root, value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Root.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> PreOrderTraversal(Node<T> root)
        {
            if (root != null)
                yield return root.Value;
            else
                yield break;

            foreach (var item in PreOrderTraversal(root.LeftChild))
                yield return item;

            foreach (var item in PreOrderTraversal(root.RightChild))
                yield return item;
        }

        public IEnumerable<T> InOrderTraversal(Node<T> root)
        {
            if (root == null)
                yield break;

            if (root.LeftChild != null)
            {
                foreach (var item in InOrderTraversal(root.LeftChild))
                    yield return item;
            }

            yield return root.Value;

            if (root.RightChild != null)
            {
                foreach (var item in InOrderTraversal(root.RightChild))
                    yield return item;
            }
        }

        public IEnumerable<T> PostOrderTraversal(Node<T> root)
        {
            if (root == null)
                yield break;


            if (root.LeftChild != null)
            {
                foreach (var item in PostOrderTraversal(root.LeftChild))
                    yield return item;
            }

            if (root.RightChild != null)
            {
                foreach (var item in PostOrderTraversal(root.RightChild))
                    yield return item;
            }

            yield return root.Value;
        }

        #region Private Methods
        private Node<T> Add(Node<T> root, T value)
        {
            if (root == null)
                root = new Node<T> { Value = value };
            else if (comparer.Compare(root.Value, value) > 0)
                root.LeftChild = Add(root.LeftChild, value);
            else if (comparer.Compare(root.Value, value) > 0)
                root.RightChild = Add(root.RightChild, value);
            return root;
        }
        #endregion
    }

    public class Node<T>
    {
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }
        public T Value { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            if (LeftChild != null)
            {
                foreach (var item in LeftChild)
                {
                    yield return item;
                }
            }

            yield return Value;

            if (RightChild != null)
            {
                foreach (var item in RightChild)
                {
                    yield return item;
                }
            }
        }
    }
}
