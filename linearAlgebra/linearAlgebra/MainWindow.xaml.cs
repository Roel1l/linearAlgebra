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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace linearAlgebra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Matrix shape;
        public MainWindow() 
        {
            InitializeComponent();

            rectangle();

            //Matrix matrix2 = new Matrix(canvas, 2, 2);

            //matrix2.set(1, 1, 1.2);
            //matrix2.set(1, 2, 0);
            //matrix2.set(2, 1, 0);
            //matrix2.set(2, 2, 1.1);

            //shape = new Matrix(canvas, 2, 4);

            //shape.set(1, 1, 30);
            //shape.set(1, 2, 40);
            //shape.set(1, 3, 60);
            //shape.set(1, 4, 10);

            //shape.set(2, 1, 20);
            //shape.set(2, 2, 10);
            //shape.set(2, 3, 70);
            //shape.set(2, 4, 50);

            //shape.draw();

            //Matrix m = scaleMatrices(matrix2, shape);
            //double?[] a = m.getRow(1);
            //double?[] b = m.getRow(2);

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                   
                    break;
                case Key.Left:
                    
                    break;
                case Key.Up:
                    
                    break;
                case Key.Down:
                    
                    break;
                case Key.Space:
                    Matrix matrix2 = new Matrix(canvas, 2, 2);

                    matrix2.set(1, 1, 1.1);
                    matrix2.set(1, 2, 0);
                    matrix2.set(2, 1, 0);
                    matrix2.set(2, 2, 1.1);
                    shape.undraw();
                    shape = scaleMatrices(matrix2, shape);
                    shape.draw();
                    break;
            }
        }
        
        private Matrix scaleMatrices(Matrix A, Matrix B)
        {
            Matrix C;
            C = new Matrix(canvas, A.rows, B.columns);
            for (int row = 1; row <= C.rows; row++)
            {
                for (int column = 1; column <= C.columns; column++)
                {
                    C.set(row, column, rowTimesColumn(A.getRow(row), B.getColumn(column)));
                }
            }
            return C;
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

        private void rectangle()
        {
            shape = new Matrix(canvas, 2, 4);

            shape.set(1, 1, 100);
            shape.set(1, 2, 500);
            shape.set(1, 3, 500);
            shape.set(1, 4, 100);

            shape.set(2, 1, 100);
            shape.set(2, 2, 100);
            shape.set(2, 3, 500);
            shape.set(2, 4, 500);

            shape.draw();

        }

        private void scaleMatrixTest()
        {
            Matrix A = new Matrix(canvas, 2, 2);
            A.set(1, 1, 4);
            A.set(1, 2, 1);
            A.set(2, 1, 2);
            A.set(2, 2, 3);

            Matrix B = new Matrix(canvas, 2, 3);
            B.set(1, 1, 3);
            B.set(1, 2, 0);
            B.set(1, 3, 4);

            B.set(2, 1, 2);
            B.set(2, 2, 5);
            B.set(2, 3, 1);

            Matrix newMatrix = scaleMatrices(A, B);
            double?[] a = newMatrix.getRow(1);
            double?[] b = newMatrix.getRow(2);

        }
    }


}
