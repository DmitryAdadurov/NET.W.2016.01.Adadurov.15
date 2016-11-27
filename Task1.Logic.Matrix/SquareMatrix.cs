using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic.Matrix
{
    public class SquareMatrix<T> : Matrix<T>
    {
        private T[,] matrix;

        public SquareMatrix(T[,] array)
        {
            if (array != null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(array));

            if (!IsSquare(array))
                throw new ArgumentOutOfRangeException(nameof(array));

            matrix = array;
            Order = matrix.GetLength(0);
        }

        public override T[,] GetArray()
        {
            return matrix;
        }

        public override void Accept(IMatrixVisitor matrixVisitor)
        {
            matrixVisitor.Visit(this);
        }

        public event EventHandler<MatrixChangedEventArgs> MatrixChanged = delegate { };

        protected virtual void OnMatrixChanged(MatrixChangedEventArgs e)
        {
            EventHandler<MatrixChangedEventArgs> temp = MatrixChanged;
            temp?.Invoke(this, e);
        }
    }
}
