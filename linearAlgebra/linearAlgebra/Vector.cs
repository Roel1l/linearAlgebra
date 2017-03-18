using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace linearAlgebra
{
    class Vector
    {
        private Canvas canvas;
        private double length;
        public double x;
        public double y;
        public double originX = 0;
        public double originY = 0;
        private Line vector;

        public Vector(Canvas canvas, double x, double y)
        {
            this.canvas = canvas;
            this.x = x;
            this.y = y;

            vector = new Line();
            vector.Stroke = Brushes.Black;
            vector.StrokeThickness = 2;
        }

        public void draw()
        {
            canvas.Children.Remove(vector);
            vector.X1 = originX;
            vector.Y1 = originY;
            vector.X2 = x;
            vector.Y2 = y;
            canvas.Children.Add(vector);
        }
    }
}
