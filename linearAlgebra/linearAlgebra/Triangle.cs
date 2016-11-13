using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace linearAlgebra
{
    class Triangle
    {
        private Canvas canvas;
        private Point A;
        private Point B;
        private Point C;
        private Line lineAB;
        private Line lineAC;
        private Line lineCB;

        public Triangle(Canvas canvas)
        {
            this.canvas = canvas;
            drawPoints();
            drawLines();
        }

        public void drawPoints()
        {
            A = new Point(canvas, 50, 100);
            B = new Point(canvas, 200, 100);
            C = new Point(canvas, 50, 200);
        }

        public void drawLines()
        {
            lineAB = new Line();
            lineAC = new Line();
            lineCB = new Line();

            lineAB.Stroke = Brushes.Black;
            lineAC.Stroke = Brushes.Black;
            lineCB.Stroke = Brushes.Black;

            lineAB.X1 = A.x;
            lineAB.Y1 = A.y;
            lineAB.X2 = B.x;
            lineAB.Y2 = B.y;

            lineAC.X1 = A.x;
            lineAC.Y1 = A.y;
            lineAC.X2 = C.x;
            lineAC.Y2 = C.y;

            lineCB.X1 = C.x;
            lineCB.Y1 = C.y;
            lineCB.X2 = B.x;
            lineCB.Y2 = B.y;

            canvas.Children.Add(lineAB);
            canvas.Children.Add(lineAC);
            canvas.Children.Add(lineCB);
        }
    }
}
