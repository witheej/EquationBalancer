using System;
using System.Data;

namespace EquationBalancer.Helpers
{
    public class Matrix
    {
        private readonly int _rows;
        private readonly int _columns;
        private readonly double[,] _matrix;

        public Matrix(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;

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
            _rows = matrix.GetLength(0);
            _columns = matrix.GetLength(1);
            _matrix = matrix;
        }


        public Matrix IdentityMatrix()
        {
            Matrix matrix = new Matrix(_rows, _columns);
            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
        }

        public double this[int row, int column]
        {
            get
            {
                if (row < 0 || row > _rows)
                    throw new Exception("Row out of Range");

                if (column < 0 || column > _columns)
                    throw new Exception("Column is out of range");

                return _matrix[row, column];
            }
            set => _matrix[row, column] = value;
        }

        public int GetRows => _rows;
        public int GetColumns => _columns;
    }
}