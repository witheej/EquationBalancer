using System;
using System.Security.Principal;

namespace EquationBalancer.Helpers
{
    public class GaussJordan
    {

        private static void Triangulate(Matrix A, Matrix b)
        {
            var rows = A.Rows;

            for (var i = 0; i < rows - 1; i++)
            {

            }
        }

        private static double Pivot(Matrix A, Matrix b, int q)
        {
            var rows = b.Rows;
            var c = q;
            var d = 0.0;

            for (var j = q; j < rows; j++)
            {
                var w = Math.Abs(A[j, q]);
                if (w > d)
                {
                    d = w;
                    c = j;
                }
            }

            if (c > q)
            {
                SwapRows(A, q, c);
                SwapColumns(b, q, c);
            }

            return A[q, q];

        }

        private static void SwapColumns(Matrix matrix, int rows,  int columns)
        {

            for (var i = 0; i < matrix.Rows; i++)
            {
                var temp = matrix[i, rows];
                matrix[i, rows] = matrix[i, columns];
                matrix[i, columns] = temp;
            }
        }

        private static void SwapRows(Matrix matrix, int rows, int columns)
        {
            for (var i = 0; i < matrix.Columns; i++)
            {
                var temp = matrix[rows, i];
                matrix[rows, i] = matrix[columns, i];
                matrix[columns, i] = temp;
            }

        }
    }
}