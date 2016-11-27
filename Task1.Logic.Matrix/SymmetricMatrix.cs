using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic.Matrix
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        private T[,] matrix;

        public SymmetricMatrix(T[,] array)
        {
            if (array != null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(array));

            if (!IsSquare(array))
                throw new ArgumentOutOfRangeException(nameof(array));

            if (!IsSymmetric(array))
                throw new ArgumentOutOfRangeException(nameof(array));

            matrix = array;
            Order = matrix.GetLength(0);
        }

        public override void Accept(IMatrixVisitor matrixVisitor)
        {
            matrixVisitor.Visit(this);
        }

        public override T[,] GetArray()
        {
            return matrix;
        }

        public event EventHandler<MatrixChangedEventArgs> MatrixChanged = delegate { };

        protected virtual void OnMatrixChanged(MatrixChangedEventArgs e)
        {
            EventHandler<MatrixChangedEventArgs> temp = MatrixChanged;
            temp?.Invoke(this, e);
        }

        #region Private Methods
        private bool IsSymmetric(T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (!array[i, j].Equals(array[j, i]))
                        return false;
                }
            }
            return true;
        }
        #endregion
    }
}
