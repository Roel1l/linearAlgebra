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
        private int length;
        public int directionX;
        public int directionY;
        public double startX;
        public double startY;
        private Line vector = new Line();

        public Vector(Canvas canvas, int directionX, int directionY)
        {
            this.canvas = canvas;
            this.directionX = directionX;
            this.directionY = directionY;

            this.startX = canvas.Width / 2;
            this.startY = canvas.Height / 2;
        }

        public void draw()
        {
            Line vector = new Line();
            vector.Stroke = Brushes.Black;
            vector.StrokeThickness = 2;

            vector.X1 = startX;
            vector.Y1 = startY;
            vector.X2 = startX + directionX;
            vector.Y2 = startY + directionY;

            canvas.Children.Add(vector);
        }
    }
}
