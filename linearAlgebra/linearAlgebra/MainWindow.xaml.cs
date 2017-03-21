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

        Point p;
        Vector v;

        public MainWindow() 
        {
            InitializeComponent();

            Matrix matrix = new Matrix(canvas, 2, 4);

            matrix.set(1, 1, 100);
            matrix.set(1, 2, 500);
            matrix.set(1, 3, 500);
            matrix.set(1, 4, 100);

            matrix.set(2, 1, 100);
            matrix.set(2, 2, 100);
            matrix.set(2, 3, 500);
            matrix.set(2, 4, 500);

            matrix.draw();

            Matrix matrix2 = new Matrix(canvas, 2, 2);

            matrix2.set(1, 1, 1.2);
            matrix2.set(1, 2, 0);
            matrix2.set(2, 1, 0);
            matrix2.set(2, 2, 1.1);


            //v = new Vector(canvas, 10, 10);
            //v.draw();
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

            }

           
        }
        
        private void scaleMatrices(Matrix A, Matrix B)
        {
            Matrix C;
            C = new Matrix(canvas, B.rows, A.columns);
            for (int row = 1; row <= C.rows; row++)
            {
                for (int column = 1; column <= C.columns; column++)
                {
                    double? result = A.get(row, column);
                }
            }

        }
    }


}
