using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic.Matrix
{
    public abstract class Matrix<T>
    {
        public abstract void Accept(IMatrixVisitor matrixVisitor);
        public abstract T[,] GetArray();

        public int Order { get; protected set; } = 0;

        #region Private Service Methods
        protected bool IsSquare(T[,] array)
        {
            if (array.Rank > 2)
                return false;

            if (array.GetLength(0) != array.GetLength(1))
                return false;

            return true;
        }

        protected MatrixChangedEventArgs CreateEventArgs(int i, int j)
        {
            return new MatrixChangedEventArgs(i, j);
        }
        #endregion
    }
}
