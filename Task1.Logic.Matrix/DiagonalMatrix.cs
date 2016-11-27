using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic.Matrix
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        private T[] matrixDiagonal;

        public DiagonalMatrix(T[,] array)
        {
            if (array != null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(array));

            if (!IsSquare(array))
                throw new ArgumentOutOfRangeException(nameof(array));

            if (!IsDiagonal(array))
                throw new ArgumentOutOfRangeException(nameof(array));

            matrixDiagonal = new T[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                matrixDiagonal[i] = array[i, i];
            }
            Order = array.GetLength(0);
        }

        public override T[,] GetArray()
        {
            T[,] resArr = new T[Order, Order];

            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    if (i == j)
                        resArr[i, j] = matrixDiagonal[i];
                    else
                        resArr[i, j] = default(T);
                }
            }
            return resArr;
        }

        public override void Accept(IMatrixVisitor matrixVisitor)
        {
            matrixVisitor.Visit(this);
        }

        #region Private Methods
        private bool IsDiagonal(T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == j)
                        continue;

                    if (!array[i, j].Equals(default(T)))
                        return false;
                }
            }
            return true;
        }

        public event EventHandler<MatrixChangedEventArgs> MatrixChanged = delegate { };

        protected virtual void OnMatrixChanged(MatrixChangedEventArgs e)
        {
            EventHandler<MatrixChangedEventArgs> temp = MatrixChanged;
            temp?.Invoke(this, e);
        }

        #endregion
    }
}
