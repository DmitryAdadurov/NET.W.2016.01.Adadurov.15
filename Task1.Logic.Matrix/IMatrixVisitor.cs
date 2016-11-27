using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logic.Matrix
{
    public interface IMatrixVisitor
    {
        SquareMatrix<T> Visit<T>(SymmetricMatrix<T> squareMatrix);
        SquareMatrix<T> Visit<T>(DiagonalMatrix<T> diagonalMatrix);
        SquareMatrix<T> Visit<T>(SquareMatrix<T> squareMatrix);
    }
}
