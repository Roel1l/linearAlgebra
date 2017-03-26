using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace linearAlgebra
{
    class Point
    {
        private Canvas canvas;
        public double y { get; set; }
        public double x { get; set; }
        private Line line1;
        private Line line2;
        public Point(Canvas canvas, double x, double y)
        {
            this.canvas = canvas;
            this.x = x;
            this.y = y;

            line1 = new Line();
            line2 = new Line();

            line1.Stroke = Brushes.Black;
            line2.Stroke = Brushes.Black;
            line1.StrokeThickness = 1;
            line2.StrokeThickness = 1;


        }

        public void draw()
        {
            this.canvas.Children.Remove(line1);
            this.canvas.Children.Remove(line2);

            line1.X1 = x - 5;
            line1.Y1 = y - 5;

            line1.X2 = x + 5;
            line1.Y2 = y + 5;

            line2.X1 = x - 5;
            line2.Y1 = y + 5;

            line2.X2 = x + 5;
            line2.Y2 = y - 5;

            this.canvas.Children.Add(line1);
            this.canvas.Children.Add(line2);
        }

        public void undraw()
        {
            this.canvas.Children.Remove(line1);
            this.canvas.Children.Remove(line2);
        }
    }
}
