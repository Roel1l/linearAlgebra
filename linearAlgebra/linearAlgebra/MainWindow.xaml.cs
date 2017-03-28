using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace linearAlgebra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Matrix cubeMatrix;
        public MainWindow() 
        {
            InitializeComponent();
            initShapeMatrix();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:               
                    cubeMatrix = translate(cubeMatrix, 5, 0);
                    cubeMatrix.draw(cube);
                    break;
                case Key.Left:           
                    cubeMatrix = translate(cubeMatrix, -5, 0);
                    cubeMatrix.draw(cube);
                    break;
                case Key.Up:                 
                    cubeMatrix = translate(cubeMatrix, 0, -5);
                    cubeMatrix.draw(cube);
                    break;
                case Key.Down:              
                    cubeMatrix = translate(cubeMatrix, 0, 5);
                    cubeMatrix.draw(cube);
                    break;
                case Key.OemMinus:                        
                    cubeMatrix = scale(cubeMatrix, 0.9, 0.9);
                    cubeMatrix.draw(cube);
                    break;
                case Key.OemPlus:          
                    cubeMatrix = scale(cubeMatrix, 1.1, 1.1);
                    cubeMatrix.draw(cube);
                    break;
                case Key.D:
                    cubeMatrix = rotateMatrix(cubeMatrix, 10, 300, 300);
                    cubeMatrix.draw(cube);
                    break;
                case Key.A:
                    cubeMatrix = rotateMatrix(cubeMatrix, -10, 300, 300);
                    cubeMatrix.draw(cube);
                    break;
                case Key.Z:
                    cubeMatrix = scaleAndTranslate(cubeMatrix, 1.1, 1.1, -10, -10);
                    cubeMatrix.draw(cube);
                    break;
                case Key.Space:
                    cubeMatrix.set(1, 1, 2);
                    cubeMatrix.draw(cube);
                    break;
            }
        }
        
        private Matrix multiplyMatrices(Matrix A, Matrix B)
        {
            Matrix C;
            C = new Matrix(A.rows, B.columns);
            for (int row = 1; row <= C.rows; row++)
            {
                for (int column = 1; column <= C.columns; column++)
                {
                    C.set(row, column, rowTimesColumn(A.getRow(row), B.getColumn(column)));
                }
            }
            return C;
        }

        private Matrix translate(Matrix matrixToTranslate, double translationX, double translationY)
        {
            if (matrixToTranslate.rows != 2) throw new Exception("Incorrect number of rows in matrix to translate (should be 2)");

            Matrix translationMatrix = new Matrix(3, 3);
            translationMatrix.set(1, 1, 1);
            translationMatrix.set(1, 2, 0);
            translationMatrix.set(1, 3, translationX);

            translationMatrix.set(2, 1, 0);
            translationMatrix.set(2, 2, 1);
            translationMatrix.set(2, 3, translationY);

            translationMatrix.set(3, 1, 0);
            translationMatrix.set(3, 2, 0);
            translationMatrix.set(3, 3, 1);

            matrixToTranslate.rows = 3;
            for(int i = 1; i <= matrixToTranslate.columns; i++)
            {
                matrixToTranslate.set(3, i, 1);
            }

            Matrix translatedMatrix = multiplyMatrices(translationMatrix, matrixToTranslate);
            translatedMatrix.rows = 2;

            return translatedMatrix;
        }

        private Matrix scale(Matrix matrixToScale, double scaleX, double scaleY)
        {
            if (matrixToScale.rows != 2) throw new Exception("Incorrect number of rows in matrix to translate (should be 2)");

            Matrix scalingMatrix = new Matrix(2, 2);

            scalingMatrix.set(1, 1, scaleX);
            scalingMatrix.set(1, 2, 0);
            scalingMatrix.set(2, 1, 0);
            scalingMatrix.set(2, 2, scaleY);

            Matrix scaledMatrix = multiplyMatrices(scalingMatrix, matrixToScale);

            return scaledMatrix;
        }

        private Matrix scaleAndTranslate(Matrix matrixToUpdate, double scaleX, double scaleY, double translationX, double translationY)
        {
            if (matrixToUpdate.rows != 2) throw new Exception("Incorrect number of rows in matrix to translate (should be 2)");

            Matrix updateMatrix = new Matrix(3, 3);
            updateMatrix.set(1, 1, scaleX);
            updateMatrix.set(1, 2, 0);
            updateMatrix.set(1, 3, translationX);

            updateMatrix.set(2, 1, 0);
            updateMatrix.set(2, 2, scaleY);
            updateMatrix.set(2, 3, translationY);

            updateMatrix.set(3, 1, 0);
            updateMatrix.set(3, 2, 0);
            updateMatrix.set(3, 3, 1);

            matrixToUpdate.rows = 3;
            for (int i = 1; i <= matrixToUpdate.columns; i++)
            {
                matrixToUpdate.set(3, i, 1);
            }

            Matrix returnMatrix = multiplyMatrices(updateMatrix, matrixToUpdate);
            returnMatrix.rows = 2;

            return returnMatrix;
        }

        private Matrix rotateMatrix(Matrix matrixToRotate, double degrees, double rotationPointX, double rotationPointY)
        {
            double theta = Math.Sin(degrees * (Math.PI / 180.0));
            double cos = Math.Cos(theta);
            double sin = Math.Sin(theta);

            Matrix rotationMatrix = new Matrix(2, 2);
            rotationMatrix.set(1, 1, cos);
            rotationMatrix.set(1, 2, -sin);
            rotationMatrix.set(2, 1, sin);
            rotationMatrix.set(2, 2, cos);

            Matrix translatedToOrigin = translate(matrixToRotate, -rotationPointX, -rotationPointY);

            Matrix rotatedMatrix = multiplyMatrices(rotationMatrix, translatedToOrigin);

            Matrix translatedBack = translate(rotatedMatrix, rotationPointX, rotationPointY);

            return translatedBack;
        }

        private double rowTimesColumn(double?[] row, double?[] column)
        {
            if (row.Length != column.Length) throw new Exception();

            double? answer = 0;

            for(int i = 0; i < row.Length; i++)
            {
                answer += row[i] * column[i];
            }

            return (double)answer;
        }

        private void initShapeMatrix()
        {
            var positions = cube.Positions;

            cubeMatrix = new Matrix(3, 8);

            for (var i = 0; i < positions.Count; i++)
            {
                cubeMatrix.set(1, i+1, positions[i].X);
                cubeMatrix.set(2, i+1, positions[i].Y);
                cubeMatrix.set(3, i+1, positions[i].Z);
            } 
        }
    }
}
