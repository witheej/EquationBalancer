using System;
using System.Text;

namespace EquationBalancer.Helpers
{
    public struct Matrix
    {

        private readonly double[,] _matrix;
        public int Rows { get; }
        public int Columns { get; }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            _matrix = new double[rows, columns];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    _matrix[i, j] = 0.0;
                }
            }
        }

        public Matrix(double[,] matrix)
        {
            Rows = matrix.GetLength(0);
            Columns = matrix.GetLength(1);
            _matrix = matrix;
        }

        public Matrix Transpose()
        {
            Matrix matrix = new Matrix(Columns, Rows);

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    matrix[j, i] = _matrix[i, j];
                }
            }

            return matrix;
        }

        public double this[int row, int column]
        {
            get
            {
                if (row < 0 || row > Rows)
                    throw new Exception("Row out of Range");

                if (column < 0 || column > Columns)
                    throw new Exception("Column is out of range");

                return _matrix[row, column];
            }
            set => _matrix[row, column] = value;
        }

        public override string ToString()
        {
            var matrixString = new StringBuilder();
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    matrixString.Append(_matrix[i, j]);
                    matrixString.Append(" ");
                }

                matrixString.AppendLine();
            }

            return matrixString.ToString();
        }

        public bool Equals(Matrix matrix) => _matrix == matrix._matrix;
        public static bool operator ==(Matrix mat1, Matrix mat2) => mat1.Equals(mat2);
        public static bool operator !=(Matrix mat1, Matrix mat2) => !mat1.Equals(mat2);

        public static Matrix operator +(Matrix matrix) => matrix;

        public static Matrix operator +(Matrix mat1, Matrix mat2)
        {
            if (!CompareDimension(mat1, mat2))
                throw new Exception("Matrix dimensions must be the same");

            Matrix sum = new Matrix(mat1.Rows, mat1.Columns);
            for (var i = 0; i < mat1.Rows; i++)
            {
                for (var j = 0; j < mat1.Columns; j++)
                {
                    sum[i, j] = mat1[i, j] + mat2[i, j];
                }
            }

            return sum;
        }

        public static Matrix operator -(Matrix matrix)
        {
            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    matrix[i, j] = -matrix[i, j];
                }
            }

            return matrix;
        }

        public static Matrix operator -(Matrix mat1, Matrix mat2)
        {
            if (!CompareDimension(mat1, mat2))
                throw new Exception("Dimenions of the matrices must be the same");

            Matrix difference = new Matrix(mat1.Rows, mat1.Columns);

            for (var i = 0; i < mat1.Rows; i++)
            {
                for (var j = 0; j < mat1.Columns; j++)
                {
                    difference[i, j] = mat1[i, j] - mat2[i, j];
                }
            }

            return difference;
        }

        public static Matrix operator *(Matrix matrix, double constant)
        {
            Matrix product = new Matrix(matrix.Rows, matrix.Columns);
            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    product[i, j] = matrix[i, j] * constant;
                }
            }

            return product;
        }

        public static Matrix operator *(double constant, Matrix matrix)
        {
            Matrix product = new Matrix(matrix.Rows, matrix.Columns);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    product[i, j] = constant * matrix[i, j];
                }
            }

            return product;
        }

        public static Matrix operator *(Matrix mat1, Matrix mat2)
        {
            if (mat1.Columns != mat2.Rows)
                throw new Exception("Columns in the first matrix should be equal to the rows in the second");

            Matrix product = new Matrix(mat1.Rows, mat2.Columns);

            for (var i = 0; i < mat1.Rows; i++)
            {
                for (var j = 0; j < mat2.Columns; j++)
                {
                    product[i, j] = 0;
                    for (var k = 0; k < product.Rows; k++)
                    {
                        product[i, j] += mat1[i, k] * mat2[k, j];
                    }
                }
            }

            return product;
        }

        public static Matrix operator /(Matrix matrix, double constant)
        {
            Matrix product = new Matrix(matrix.Rows, matrix.Columns);
            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    product[i, j] = matrix[i, j] / constant;
                }
            }

            return product;
        }

        public static Matrix operator /(double constant, Matrix matrix)
        {
            Matrix product = new Matrix(matrix.Rows, matrix.Columns);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    product[i, j] = constant / matrix[i, j];
                }
            }

            return product;
        }

        public static bool CompareDimension(Matrix mat1, Matrix mat2)
        {
            return mat1.Rows == mat2.Rows && mat1.Columns == mat2.Columns;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Matrix matrix && Equals(matrix);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_matrix != null ? _matrix.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Rows;
                hashCode = (hashCode * 397) ^ Columns;
                return hashCode;
            }
        }
    }
}