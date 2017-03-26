using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace linearAlgebra
{
    class Rope
    {
        private Canvas canvas;
        private Line rope;
        public double X1;
        public double X2;
        public double Y1;
        public double Y2;
        public Rope(Canvas canvas, double X1, double Y1, double X2, double Y2)
        {
            this.canvas = canvas;
            this.X1 = X1;
            this.Y1 = Y1;
            this.X2 = X2;
            this.Y2 = Y2;

            rope = new Line();
            rope.Stroke = Brushes.Black;
            rope.StrokeThickness = 2;
        }

        public void draw()
        {
            canvas.Children.Remove(rope);
            rope.X1 = X1;
            rope.Y1 = Y1;
            rope.X2 = X2;
            rope.Y2 = Y2;
            canvas.Children.Add(rope);
        }

        public void undraw()
        {
            canvas.Children.Remove(rope);
        }
    }
}
