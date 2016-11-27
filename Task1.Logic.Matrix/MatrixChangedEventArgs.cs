using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic.Matrix
{
    #region EventArgs
    public sealed class MatrixChangedEventArgs : EventArgs
    {
        private readonly int i, j;

        public MatrixChangedEventArgs(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public int IndexI { get { return i; } }
        public int IndexJ { get { return j; } }
    }
    #endregion
}
