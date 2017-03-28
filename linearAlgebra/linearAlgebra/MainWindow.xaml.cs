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
                    cubeMatrix = translate(cubeMatrix, 0.1, 0, 0);
                    cubeMatrix.draw(cube);
                    break;
                case Key.Left:           
                    cubeMatrix = translate(cubeMatrix, -0.1, 0, 0);
                    cubeMatrix.draw(cube);
                    break;
                case Key.Up:                 
                    cubeMatrix = translate(cubeMatrix, 0, 0.1, 0);
                    cubeMatrix.draw(cube);
                    break;
                case Key.Down:              
                    cubeMatrix = translate(cubeMatrix, 0, -0.1, 0);
                    cubeMatrix.draw(cube);
                    break;
                case Key.OemMinus:                        
                    cubeMatrix = scale(cubeMatrix, 0.9, 0.9, 0.9);
                    cubeMatrix.draw(cube);
                    break;
                case Key.OemPlus:          
                    cubeMatrix = scale(cubeMatrix, 1.1, 1.1, 1.1);
                    cubeMatrix.draw(cube);
                    break;
                case Key.D:
                    cubeMatrix = rotate3D(cubeMatrix, 10, 10, 8, 6);
                    cubeMatrix.draw(cube);
                    break;
                case Key.A:
                    cubeMatrix = rotate3D(cubeMatrix, -10, 10, 8, 6);
                    cubeMatrix.draw(cube);
                    break;
                case Key.W:
                    cubeMatrix = rotate3D(cubeMatrix, 10, -10, -8, 6);
                    cubeMatrix.draw(cube);
                    break;
                case Key.S:
                    cubeMatrix = rotate3D(cubeMatrix, -10, -10, -8, 6);
                    cubeMatrix.draw(cube);
                    break;
                case Key.Z:
                    cubeMatrix = scaleAndTranslate(cubeMatrix, 1.1, 1.1, 1.1, -0.1, -0.1, -0.1);
                    cubeMatrix.draw(cube);
                    break;
                case Key.Space:
                    break;
            }

            //textBox.Clear();

            //for (int column = 1; column < cubeMatrix.columns; column++)
            //{
            //    textBox.Text += "X: " + Math.Round((double)cubeMatrix.get(1, column), 2) + ", ";
            //    textBox.Text += "Y: " + Math.Round((double)cubeMatrix.get(2, column), 2) + ", ";
            //    textBox.Text += "Z: " + Math.Round((double)cubeMatrix.get(3, column), 2) + "\n";
            //}
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

        private Matrix translate(Matrix matrixToTranslate, double translationX, double translationY, double translationZ)
        {
            if (matrixToTranslate.rows != 3) throw new Exception("Incorrect number of rows in matrix to translate (should be 3)");

            Matrix translationMatrix = new Matrix(4, 4);
            translationMatrix.set(1, 1, 1);
            translationMatrix.set(1, 2, 0);
            translationMatrix.set(1, 3, 0);
            translationMatrix.set(1, 4, translationX);

            translationMatrix.set(2, 1, 0);
            translationMatrix.set(2, 2, 1);
            translationMatrix.set(2, 3, 0);
            translationMatrix.set(2, 4, translationY);

            translationMatrix.set(3, 1, 0);
            translationMatrix.set(3, 2, 0);
            translationMatrix.set(3, 3, 1);
            translationMatrix.set(3, 4, translationZ);

            translationMatrix.set(4, 1, 0);
            translationMatrix.set(4, 2, 0);
            translationMatrix.set(4, 3, 0);
            translationMatrix.set(4, 4, 1);

            matrixToTranslate.rows = 4;
            for(int i = 1; i <= matrixToTranslate.columns; i++)
            {
                matrixToTranslate.set(4, i, 1);
            }

            Matrix translatedMatrix = multiplyMatrices(translationMatrix, matrixToTranslate);
            translatedMatrix.rows = 3;

            return translatedMatrix;
        }

        private Matrix scale(Matrix matrixToScale, double scaleX, double scaleY, double scaleZ)
        {
            if (matrixToScale.rows != 3) throw new Exception("Incorrect number of rows in matrix to translate (should be 3)");

            Matrix scalingMatrix = new Matrix(3, 3);

            scalingMatrix.set(1, 1, scaleX);
            scalingMatrix.set(1, 2, 0);
            scalingMatrix.set(1, 3, 0);

            scalingMatrix.set(2, 1, 0);
            scalingMatrix.set(2, 2, scaleY);
            scalingMatrix.set(2, 3, 0);

            scalingMatrix.set(3, 1, 0);
            scalingMatrix.set(3, 2, 0);
            scalingMatrix.set(3, 3, scaleZ);

            Matrix scaledMatrix = multiplyMatrices(scalingMatrix, matrixToScale);

            return scaledMatrix;
        }

        private Matrix scaleAndTranslate(Matrix matrixToUpdate, double scaleX, double scaleY, double scaleZ, double translationX, double translationY, double translationZ)
        {
            if (matrixToUpdate.rows != 3) throw new Exception("Incorrect number of rows in matrix to translate (should be 3)");

            Matrix updateMatrix = new Matrix(4, 4);
            updateMatrix.set(1, 1, scaleX);
            updateMatrix.set(1, 2, 0);
            updateMatrix.set(1, 3, 0);
            updateMatrix.set(1, 4, translationX);

            updateMatrix.set(2, 1, 0);
            updateMatrix.set(2, 2, scaleY);
            updateMatrix.set(2, 3, 0);
            updateMatrix.set(2, 4, translationY);

            updateMatrix.set(3, 1, 0);
            updateMatrix.set(3, 2, 0);
            updateMatrix.set(3, 3, scaleZ);
            updateMatrix.set(3, 4, translationZ);

            updateMatrix.set(4, 1, 0);
            updateMatrix.set(4, 2, 0);
            updateMatrix.set(4, 3, 0);
            updateMatrix.set(4, 4, 1);

            matrixToUpdate.rows = 4;
            for (int i = 1; i <= matrixToUpdate.columns; i++)
            {
                matrixToUpdate.set(4, i, 1);
            }

            Matrix returnMatrix = multiplyMatrices(updateMatrix, matrixToUpdate);
            returnMatrix.rows = 3;

            return returnMatrix;
        }

        private Matrix rotate2D(Matrix matrixToRotate, double degrees, double rotationPointX, double rotationPointY)
        {
            double theta = Math.Sin(degrees * (Math.PI / 180.0));
            double cos = Math.Cos(theta);
            double sin = Math.Sin(theta);

            Matrix rotationMatrix = new Matrix(2, 2);
            rotationMatrix.set(1, 1, cos);
            rotationMatrix.set(1, 2, -sin);
            rotationMatrix.set(2, 1, sin);
            rotationMatrix.set(2, 2, cos);

            Matrix translatedToOrigin = translate(matrixToRotate, -rotationPointX, -rotationPointY, 0);

            Matrix rotatedMatrix = multiplyMatrices(rotationMatrix, translatedToOrigin);

            Matrix translatedBack = translate(rotatedMatrix, rotationPointX, rotationPointY, 0);

            return translatedBack;
        }

        private Matrix rotate3D(Matrix matrixToRotate, double degrees, double rotationPointX, double rotationPointY, double rotationPointZ)
        {
            double theta = Math.Sin(degrees * (Math.PI / 180.0));
            double t1 = Math.Atan2(rotationPointZ, rotationPointX);
            double t2 = Math.Atan2(rotationPointY, Math.Sqrt((Math.Pow(rotationPointX, 2)+ Math.Pow(rotationPointZ, 2))));
            double cos = Math.Cos(theta);
            double sin = Math.Sin(theta);

            Matrix M12 = BringToXAxis(t1, t2);

            Matrix M3 = new Matrix(3, 3);
            M3.set(1, 1, 1);
            M3.set(1, 2, 0);
            M3.set(1, 3, 0);
            
            M3.set(2, 1, 0);
            M3.set(2, 2, cos);
            M3.set(2, 3, -sin);
            
            M3.set(3, 1, 0);
            M3.set(3, 2, sin);
            M3.set(3, 3, cos);

            Matrix M123 = multiplyMatrices(M3, M12);

            Matrix M12345 = getBackToStartPosition(M123, t1, t2);



            return multiplyMatrices(M12345, matrixToRotate);
        }

        private Matrix getBackToStartPosition(Matrix M123, double t1, double t2)
        {
            Matrix M5 = new Matrix(3, 3);
            double sinT1 = Math.Sin(t1);
            double cosT1 = Math.Cos(t1);
            double sinT2 = Math.Sin(t2);
            double cosT2 = Math.Cos(t2);

            M5.set(1, 1, cosT1);
            M5.set(1, 2, 0);
            M5.set(1, 3, -sinT1);

            M5.set(2, 1, 0);
            M5.set(2, 2, 1);
            M5.set(2, 3, 0);

            M5.set(3, 1, sinT1);
            M5.set(3, 2, 0);
            M5.set(3, 3, cosT1);

            Matrix M4 = new Matrix(3, 3);

            M4.set(1, 1, cosT2);
            M4.set(1, 2, -sinT2);
            M4.set(1, 3, 0);

            M4.set(2, 1, sinT2);
            M4.set(2, 2, cosT2);
            M4.set(2, 3, 0);

            M4.set(3, 1, 0);
            M4.set(3, 2, 0);
            M4.set(3, 3, 1);

            Matrix M1234 = multiplyMatrices(M4, M123);
            Matrix M12345 = multiplyMatrices(M5, M1234);
            return M12345;
        }

        private Matrix BringToXAxis(double t1, double t2)
        {
            Matrix M2 = new Matrix(3, 3);
            double sinT1 = Math.Sin(t1);
            double cosT1 = Math.Cos(t1);
            double sinT2 = Math.Sin(t2);
            double cosT2 = Math.Cos(t2);

            M2.set(1, 1, cosT2);
            M2.set(1, 2, sinT2);
            M2.set(1, 3, 0);

            M2.set(2, 1, -sinT2);
            M2.set(2, 2, cosT2);
            M2.set(2, 3, 0);

            M2.set(3, 1, 0);
            M2.set(3, 2, 0);
            M2.set(3, 3, 1);

            Matrix M1 = new Matrix(3, 3);

            M1.set(1, 1, cosT1);
            M1.set(1, 2, 0);
            M1.set(1, 3, sinT1);

            M1.set(2, 1, 0);
            M1.set(2, 2, 1);
            M1.set(2, 3, 0);

            M1.set(3, 1, -sinT1);
            M1.set(3, 2, 0);
            M1.set(3, 3, cosT1);

            Matrix M12 = multiplyMatrices(M2, M1);
            return M12;
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

            cubeMatrix = new Matrix(3, positions.Count);

            for (var i = 0; i < positions.Count; i++)
            {
                cubeMatrix.set(1, i+1, positions[i].X);
                cubeMatrix.set(2, i+1, positions[i].Y);
                cubeMatrix.set(3, i+1, positions[i].Z);
            } 
        }

    }
}
