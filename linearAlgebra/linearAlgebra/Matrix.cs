using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace linearAlgebra
{
    class Matrix
    {
        private Canvas canvas;
        public int rows;
        public int columns;

        private DoubleKeyDictionary doubleKeyDictionary;
        private List<Point> matrixPoints;
        private List<Rope> matrixLines;
        
        public Matrix(Canvas canvas, int rows, int columns)
        {
            this.canvas = canvas;
            this.rows = rows;
            this.columns = columns;
            doubleKeyDictionary = new DoubleKeyDictionary();
            matrixPoints = new List<Point>();
            matrixLines = new List<Rope>();
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

        public void draw()
        {
            matrixLines.Clear();
            matrixPoints.Clear();
            for (int column = 1; column <= columns; column++)
            {
                Point point = new Point(canvas, 0 , 0);

                for (int row = 1; row <= 2; row++)
                {
                    double? value = doubleKeyDictionary.get(row, column);
                    if(value != null)
                    {
                        switch (row)
                        {
                            case 1: //X
                                point.x = (double)value;
                                break;
                            case 2: //Y
                                point.y = (double)value;
                                break;
                        }
                    }
                    else
                    {
                        throw new Exception("Not all matrix values have been entered");
                    }
                }

                matrixPoints.Add(point);
            }

            for(int pointIndex = 0; pointIndex < matrixPoints.Count; pointIndex++)
            {
                matrixPoints[pointIndex].draw();
                Rope line;
                if(pointIndex == matrixPoints.Count - 1)
                {
                    line = new Rope(canvas, matrixPoints[pointIndex].x, matrixPoints[pointIndex].y, matrixPoints[0].x, matrixPoints[0].y);
                    matrixLines.Add(line);
                }
                else
                {
                    line = new Rope(canvas, matrixPoints[pointIndex].x, matrixPoints[pointIndex].y, matrixPoints[pointIndex+1].x, matrixPoints[pointIndex + 1].y);
                    matrixLines.Add(line);
                }
                line.draw();
            }
        }

        public void undraw()
        {
            foreach(Rope r in matrixLines) r.undraw();       
            foreach (Point p in matrixPoints) p.undraw();
        }
    }


}
