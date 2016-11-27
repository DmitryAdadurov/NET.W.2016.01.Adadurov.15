using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2.Logic.BinarySearchTree;

namespace Task2.Logic.BinarySearchTreeTests
{
    [TestFixture]
    public class BinarySearchTests
    {
        static object[] testNumbers =
        {
            new int[] {7, 1, 0, 3, 2, 5, 4, 6, 9, 8, 10 }
        };

        [Test, TestCaseSource("testNumbers")]
        public void BinaryTree_InOrderTraversal_DefaultComparer_Test(int[] arr)
        {
            BinarySearch<int> bs = new BinarySearch<int>(arr);

            int[] actual = new int[arr.Length];

            int i = 0;
            foreach (var item in bs.InOrderTraversal(bs.Root))
            {
                actual[i++] = item;
            }

            int[] expected = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}
