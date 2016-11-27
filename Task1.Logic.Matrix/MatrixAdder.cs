using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic.Matrix
{
    public class MatrixAdder<T> : IMatrixVisitor
    {
        private Matrix<T> matrixContainer;
        private MatrixAdder(Matrix<T> matrix)
        {
            matrixContainer = matrix;
        }

        SquareMatrix<T> IMatrixVisitor.Visit<T>(SquareMatrix<T> squareMatrix)
        {
            var matrix = new T[matrixContainer.Order, matrixContainer.Order];
            matrixContainer.GetArray().CopyTo(matrix, 0);
            return AddMatrixes<T>(matrix, squareMatrix.GetArray(), squareMatrix.Order);
        }

        SquareMatrix<T> IMatrixVisitor.Visit<T>(DiagonalMatrix<T> diagonalMatrix)
        {
            var matrix = new T[matrixContainer.Order, matrixContainer.Order];
            matrixContainer.GetArray().CopyTo(matrix, 0);
            return AddMatrixes<T>(matrix, diagonalMatrix.GetArray(), diagonalMatrix.Order);
        }

        SquareMatrix<T> IMatrixVisitor.Visit<T>(SymmetricMatrix<T> symmetricMatrix)
        {
            var matrix = new T[matrixContainer.Order, matrixContainer.Order];
            matrixContainer.GetArray().CopyTo(matrix, 0);
            return AddMatrixes<T>(matrix, symmetricMatrix.GetArray(), symmetricMatrix.Order);
        }

        #region Private Methods
        private static SquareMatrix<R> AddMatrixes<R>(R[,] matrix1, R[,] matrix2, int order)
        { 
            if (matrix1.GetLength(0) != matrix2.GetLength(0))
                return null;

            R[,] resArr = new R[order, order];

            for (int i = 0; i < order; i++)
            {
                for (int j = 0; j < order; j++)
                {
                    resArr[i, j] = Add<R>(matrix1[i, j], matrix2[i, j]);
                }
            }

            return new SquareMatrix<R>(resArr);
        }
        private static S Add<S>(S one, S two)
        {
            var paramOne = Expression.Parameter(typeof(S), "one");
            var paramTwo = Expression.Parameter(typeof(S), "two");

            BinaryExpression be = Expression.Add(paramOne, paramTwo);

            Func<S, S, S> addition = Expression.Lambda<Func<S, S, S>>(be, paramOne, paramTwo).Compile();

            return addition(one, two);
        }
        #endregion
    }
}
