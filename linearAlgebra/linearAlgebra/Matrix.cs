using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace linearAlgebra
{
    class Matrix
    {
        public int rows;
        public int columns;

        private DoubleKeyDictionary doubleKeyDictionary;
        
        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            doubleKeyDictionary = new DoubleKeyDictionary();
        }

        public void set(int row, int column, double value)
        {
            if (row > 0 && row <= rows && column > 0 && row <= columns) {
                doubleKeyDictionary.set(row, column, value);
            }
        }

        public double?[] getRow(int rowIndex)
        {

            double?[] numbers = new double?[columns];
            for(int i = 0; i < columns; i++)
            {
                numbers[i] = doubleKeyDictionary.get(rowIndex, i + 1);
            }
            return numbers;
        }

        public double?[] getColumn(int columnIndex)
        {

            double?[] numbers = new double?[rows];
            for (int i = 0; i < rows; i++)
            {
                numbers[i] = doubleKeyDictionary.get(i + 1, columnIndex);
            }
            return numbers;
        }

        public double? get(int row, int column)
        {
            double? value = null;
            if (row > 0 && row <= rows && column > 0 && row <= columns)
            {
                value = doubleKeyDictionary.get(row, column);
            }
            return value;
        }

        public void draw(MeshGeometry3D shape)
        {
            var positions = shape.Positions;

            for (int column = 1; column <= columns; column++)
            {
                double x = (double)get(1, column);
                double y = (double)get(2, column);
                double z = (double)get(3, column);
                Point3D position = new Point3D(x, y, z);
                positions[column-1] = position;
            }
        }
    }


}
